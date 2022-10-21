using MediatR;
using System;

namespace Reservas.Application.UseCases.Command.Asientos.actualizarEstadoAsientosCommand {
	public class ActualizarAsientoCommand : IRequest<bool> {
		public string NroReserva { get; set; }
		public char Estado { get; set; }

		private ActualizarAsientoCommand() { }

		public ActualizarAsientoCommand(string nroReserva, char estado) {
			NroReserva = nroReserva;
			Estado = estado;
		}
	}
}
