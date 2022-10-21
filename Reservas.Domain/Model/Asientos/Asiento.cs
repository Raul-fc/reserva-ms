using Sharedkernel.Core;
using System;

namespace Reservas.Domain.Model.Asientos {
	public class Asiento : AggregateRoot<Guid> {
		public string NroAsiento { get; private set; }
		public char Estado { get; private set; }
		public Guid AvionId { get; private set; }
		public Guid VueloId { get; private set; }
		private Asiento() {

		}

		public Asiento(string asiento, Guid avionId, Guid vueloId) {
			Id = Guid.NewGuid();
			NroAsiento = asiento;
			AvionId = avionId;
			Estado = 'D';
			VueloId = vueloId;
		}

		public void AsientoReservado() {
			Estado = 'R';
		}
		public void AsientoVendido() {
			Estado = 'V';
		}
		public void AsientoAnulado() {
			Estado = 'D';
		}
		public void AsientoCheckIn() {
			Estado = 'C';
		}
	}
}