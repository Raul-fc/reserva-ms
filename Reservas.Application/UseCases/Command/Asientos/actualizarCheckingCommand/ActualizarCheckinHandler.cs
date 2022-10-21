using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Application.UseCases.Command.Asientos.actualizarEstadoAsientosCommand;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Asientos;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Command.Asientos.actualizarCheckingCommand {
	public class ActualizarCheckinHandler : IRequestHandler<ActualizarCheckinCommand, bool> {
		private readonly IAsientoRepository _asientoRepository;
		private readonly IReservaRepository _reservaRepository;
		private readonly ILogger<ActualizarAsientoHandler> _logger;
		private readonly IAsientoFactory _asientoFactory;
		private readonly IUnitOfWork _unitOfWork;

		public ActualizarCheckinHandler(IAsientoRepository asientoRepository, IReservaRepository reservaRepository, ILogger<ActualizarAsientoHandler> logger, IAsientoFactory asientoFactory, IUnitOfWork unitOfWork) {
			_asientoRepository = asientoRepository;
			_reservaRepository = reservaRepository;
			_logger = logger;
			_asientoFactory = asientoFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> Handle(ActualizarCheckinCommand request, CancellationToken cancellationToken) {
			bool resp = false;
			try
			{
				Reserva objReserva = await _reservaRepository.ObtReserva(request.NroReserva);
				List<Asiento> listAsientos = await _asientoRepository.obtAsientosConEstadoVendido(objReserva.IdVuelo);
				Asiento myAsiento = listAsientos[0];
				myAsiento.AsientoCheckIn();
				objReserva.VentaCheckIn();
				await _reservaRepository.UpdateAsync(objReserva);
				await _asientoRepository.UpdateAsync(myAsiento);
				await _unitOfWork.Commit();
			}
			catch
			{
			}

			return resp;
		}
	}
}
