using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Application.Service;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Asientos;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Command.Reservas.CrearReserva {
	public class CrearReservaHandler : IRequestHandler<CrearReservaCommand, Reserva> {
		private readonly IReservaRepository _reservaRepository;
		private readonly IAsientoRepository _asientosRepository;
		private readonly ILogger<CrearReservaHandler> _logger;
		private readonly IReservaService _reservaService;
		private readonly IReservaFactory _reservaFactory;
		private readonly IUnitOfWork _unitOfWork;

		public CrearReservaHandler(IReservaRepository reservaRepository, IAsientoRepository asientosRepository, ILogger<CrearReservaHandler> logger, IReservaService reservaService, IReservaFactory reservaFactory = null, IUnitOfWork unitOfWork = null) {
			_reservaRepository = reservaRepository;
			_asientosRepository = asientosRepository;
			_logger = logger;
			_reservaService = reservaService;
			_reservaFactory = reservaFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<Reserva> Handle(CrearReservaCommand request, CancellationToken cancellationToken) {
			string nroReserva = await _reservaService.GenerarNroReservaAsync();
			int nroAsientosDisponibles = _asientosRepository.verificarAsientosExistentes(request.IdVuelo);

			if (nroAsientosDisponibles < request.Detalle.Count)
			{
				throw new BussinessRuleValidationException($"Solo existen {nroAsientosDisponibles} asientos disponibles");
			}
			Reserva objReserva = _reservaFactory.Create(request.IdVuelo, nroReserva, request.FechaVuelo);

			try
			{
				int contadorAsientos = -1;
				List<Asiento> listAsientos = await _asientosRepository.obtAsientosDisponibles(objReserva.IdVuelo);
				foreach (var item in request.Detalle)
				{
					if (item.Pasajero.Length == 0)
					{
						throw new BussinessRuleValidationException($"Introducza su nombre");
					}

					if (item.NroDocumento.Length == 0)
					{
						throw new BussinessRuleValidationException($"Introducza su nro de documento");
					}

					if (item.Costo <= 0)
					{
						throw new BussinessRuleValidationException($"El costo tiene que ser mayor a 0");
					}
					contadorAsientos++;
					Asiento myAsiento = listAsientos[contadorAsientos];
					myAsiento.AsientoReservado();
					await _asientosRepository.UpdateAsync(myAsiento);

					objReserva.AgregarItem(item.Pasajero, item.NroDocumento, item.Costo);
				}
				objReserva.ConsolidarReserva();

				await _reservaRepository.CreateAsync(objReserva);
				await _unitOfWork.Commit();

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al crear la reserva");
				throw new BussinessRuleValidationException(ex.Message);
			}
			return objReserva;
		}
	}
}
