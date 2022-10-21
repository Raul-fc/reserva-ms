using Sharedkernel.Core;
using System;

namespace Sharedkernel.IntegrationEvents {
	public record Checkin : IntegrationEvent {
		public Guid id { get; set; }
		public string NroReserva { get; set; }
		public string NroAsiento { get; set; }
	}
}
