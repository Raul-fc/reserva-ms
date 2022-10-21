using Reservas.Domain.Model.Asientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Factories {
	public interface IAsientoFactory {
		Asiento Create(string asiento, Guid avionId, Guid vueloId);
	}
}
