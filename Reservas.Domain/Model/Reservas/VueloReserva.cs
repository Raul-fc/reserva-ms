using Reservas.Domain.ValueObjects;
using Sharedkernel.Core;
using System;

namespace Reservas.Domain.Model.Reservas {
	public class VueloReserva : Entity<Guid> {
		public string Pasajero { get; private set; }
		public string NroDocumento { get; private set; }
		public PrecioValue Costo { get; private set; }
		public bool Activo { get; private set; }

		internal VueloReserva(string pasajero, string nroDocumento, decimal costo) {
			Id = Guid.NewGuid();
			Pasajero = pasajero;
			NroDocumento = nroDocumento;
			Costo = costo;
			Activo = true;
		}
		private VueloReserva() { }

		internal void ModificarReserva(string pasajero, string nroDocumento, decimal costo) {
			Costo = costo;
			Pasajero = pasajero;
			NroDocumento = nroDocumento;
		}
	}
}
