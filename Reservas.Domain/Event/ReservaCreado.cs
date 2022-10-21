using Reservas.Domain.Model.Reservas;
using Sharedkernel.Core;
using System;
using System.Collections.Generic;

namespace Reservas.Domain.Event {
	public record ReservaCreado : DomainEvent {
		public Guid ReservaId { get; }
		public DateTime FechaVuelo { get; }
		public string NroReserva { get; }
		public decimal Costo { get; }
		public Guid IdVuelo { get; }
		public ICollection<VueloReserva> _vueloReserva { get; }

		public ReservaCreado(Guid reservaId, DateTime fechaVuelo, string nroReserva, decimal costo, Guid idVuelo, ICollection<VueloReserva> vueloReserva) : base(DateTime.Now) {
			ReservaId = reservaId;
			FechaVuelo = fechaVuelo;
			NroReserva = nroReserva;
			Costo = costo;
			IdVuelo = idVuelo;
			_vueloReserva = vueloReserva;
		}
	}
}
