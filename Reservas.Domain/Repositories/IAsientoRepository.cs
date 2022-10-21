using Reservas.Domain.Model.Asientos;
using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservas.Domain.Repositories {
	public interface IAsientoRepository : IRepository<Asiento, Guid> {
		int verificarAsientosExistentes(Guid idVuelo);
		Task<List<Asiento>> obtAsientosConEstadoReservado(Guid idVuelo);
		Task<List<Asiento>> obtAsientosConEstadoVendido(Guid idVuelo);
		Asiento obtAsiento(string NroAsiento);
		Task<List<Asiento>> obtAsientosDisponibles(Guid idVuelo);
		Task UpdateAsync(Asiento obj);
	}
}
