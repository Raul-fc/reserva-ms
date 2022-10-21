using Sharedkernel.Core;
using System;
using System.Collections.Generic;

namespace Sharedkernel.IntegrationEvents {
	public record VentaRegistrada : IntegrationEvent {
		public Guid Id { get; set; }
		public string NroReserva { get; set; }
		public decimal Costo { get; set; }
		public DateTime FechaVuelo { get; set; }
		public Guid IdVuelo { get; set; }
		public bool Activo { get; set; }
		public ICollection<VueloReserva> VueloReserva { get; set; }
	}
}
