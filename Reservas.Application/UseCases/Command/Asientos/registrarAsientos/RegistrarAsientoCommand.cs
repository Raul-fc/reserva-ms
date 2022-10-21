using MediatR;
using System;

namespace Reservas.Application.UseCases.Command.Asientos.registrarAsientos {
	public class RegistrarAsientoCommand : IRequest<bool> {

		public Guid AvionId { get; set; }
		public Guid VueloId { get; set; }
		public int NroAsientos { get; set; }

		private RegistrarAsientoCommand() { }

		public RegistrarAsientoCommand(Guid avionId, Guid vueloId, int nroAsientos) {
			AvionId = avionId;
			VueloId = vueloId;
			NroAsientos = nroAsientos;
		}
	}
}
