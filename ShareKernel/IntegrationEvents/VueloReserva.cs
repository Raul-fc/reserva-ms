using System;

namespace Sharedkernel.IntegrationEvents {
	public class VueloReserva {
		public Guid Id { get; set; }
		public string Pasajero { get; set; }
		public string NroDocumento { get; set; }
		public decimal Costo { get; set; }
	}
}
