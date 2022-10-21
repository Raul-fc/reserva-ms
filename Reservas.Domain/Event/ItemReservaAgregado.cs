using Reservas.Domain.ValueObjects;
using Sharedkernel.Core;
using System;

namespace Reservas.Domain.Event {
	public record ItemReservaAgregado : DomainEvent {
		public string Pasajero { get; private set; }
		public string NroDocumento { get; private set; }
		public PrecioValue Costo { get; }
		public ItemReservaAgregado(string pasajero, string nroDocumento, PrecioValue costo) : base(DateTime.Now) {
			Pasajero = pasajero;
			NroDocumento = nroDocumento;
			Costo = costo;
		}
	}
}
