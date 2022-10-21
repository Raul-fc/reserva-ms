using Reservas.Domain.Model.Asientos;
using System;

namespace Reservas.Domain.Factories {
	public class AsientoFactory : IAsientoFactory {
		public Asiento Create(string asiento, Guid avionId, Guid vueloId) {
			return new Asiento(asiento, avionId, vueloId);
		}
	}
}
