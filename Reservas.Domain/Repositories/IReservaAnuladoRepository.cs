using Reservas.Domain.Model.ReservaAnulados;
using Sharedkernel.Core;
using System;

namespace Reservas.Domain.Repositories {
	public interface IReservaAnuladoRepository : IRepository<ReservaAnulado, Guid> {
	}
}
