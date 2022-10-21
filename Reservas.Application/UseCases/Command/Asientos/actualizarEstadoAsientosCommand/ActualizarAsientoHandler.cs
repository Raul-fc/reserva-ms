using MediatR;
using Microsoft.Extensions.Logging;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Asientos;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Command.Asientos.actualizarEstadoAsientosCommand {
	public class ActualizarAsientoHandler : IRequestHandler<ActualizarAsientoCommand, bool> {
		private readonly IAsientoRepository _asientoRepository;
		private readonly IReservaRepository _reservaRepository;
		private readonly ILogger<ActualizarAsientoHandler> _logger;
		private readonly IAsientoFactory _asientoFactory;
		private readonly IUnitOfWork _unitOfWork;

		public ActualizarAsientoHandler(IAsientoRepository asientoRepository, IReservaRepository reservaRepository, ILogger<ActualizarAsientoHandler> logger, IAsientoFactory asientoFactory, IUnitOfWork unitOfWork) {
			_asientoRepository = asientoRepository;
			_reservaRepository = reservaRepository;
			_logger = logger;
			_asientoFactory = asientoFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> Handle(ActualizarAsientoCommand request, CancellationToken cancellationToken) {
			bool resp = false;
			try
			{
				Reserva objAsiento = await _reservaRepository.ObtReserva(request.NroReserva);
				List<Asiento> listAsientos = await _asientoRepository.obtAsientosConEstadoReservado(objAsiento.IdVuelo);
				var nroPasajeros = objAsiento.VueloReserva.Count;

				for (int i = 0; i < nroPasajeros; i++)
				{
					Asiento myAsiento = listAsientos[i];
					if (request.Estado == 'V')
					{
						myAsiento.AsientoVendido();
					}
					else
					{
						myAsiento.AsientoAnulado();
					}
					await _asientoRepository.UpdateAsync(myAsiento);
				}
			}
			catch
			{
			}

			return resp;
		}
	}
}
