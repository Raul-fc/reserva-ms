using Reservas.Domain.Event;
using Reservas.Domain.Model.Reservas;
using System;

namespace Reservas.Domain.Factories {
	public class ReservaFactory : IReservaFactory {
		public Reserva Create(Guid idVuelo, string nroReserva, DateTime fechaVuelo) {
			var obj = new Reserva(idVuelo, nroReserva, fechaVuelo);
			//var domainEvent = new ReservaCreado(obj.Id, nroReserva, obj.Costo, obj.IdVuelo);

			//obj.AddDomainEvent(domainEvent);
			return obj;
		}
	}
}
