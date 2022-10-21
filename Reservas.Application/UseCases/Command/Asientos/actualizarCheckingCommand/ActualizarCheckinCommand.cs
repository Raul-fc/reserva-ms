using MediatR;
using System;

namespace Reservas.Application.UseCases.Command.Asientos.actualizarCheckingCommand {
	public class ActualizarCheckinCommand : IRequest<bool> {
		public Guid Id { get; set; }
		public string NroReserva { get; set; }
		public string NroAsiento { get; set; }

		private ActualizarCheckinCommand() { }

		public ActualizarCheckinCommand(Guid id, string nroReserva, string nroAsiento) {
			Id = id;
			NroReserva = nroReserva;
			NroAsiento = nroAsiento;
		}
	}
}
