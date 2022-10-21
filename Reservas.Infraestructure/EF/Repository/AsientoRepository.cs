using Microsoft.EntityFrameworkCore;
using Reservas.Domain.Model.Asientos;
using Reservas.Domain.Repositories;
using Reservas.Infraestructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.Repository {
	public class AsientoRepository : IAsientoRepository {
		public readonly DbSet<Asiento> _asiento;

		public AsientoRepository(WriteDbContext context) {
			_asiento = context.Asiento;

		}
		public async Task CreateAsync(Asiento obj) {
			await _asiento.AddAsync(obj);
		}

		public Task<Asiento> FindByIdAsync(Guid id) {
			throw new NotImplementedException();
		}

		public int verificarAsientosExistentes(Guid idVuelo) {
			return (from asi in _asiento.AsEnumerable()
					where asi.VueloId == idVuelo && asi.Estado == 'D'
					select asi).Count();
		}
		public async Task<List<Asiento>> obtAsientosConEstadoReservado(Guid idVuelo) {
			var data = await _asiento
				.Where(x => x.Estado == 'R' && x.VueloId == idVuelo)
				.ToListAsync();
			return data;
		}

		public async Task<List<Asiento>> obtAsientosConEstadoVendido(Guid idVuelo) {
			var data = await _asiento
				.Where(x => x.Estado == 'V' && x.VueloId == idVuelo)
				.ToListAsync();
			return data;
		}

		public Asiento obtAsiento(string NroAsiento) {
			var data = _asiento
				.Where(x => x.NroAsiento == NroAsiento)
				.FirstOrDefault();
			return data;
		}

		public async Task<List<Asiento>> obtAsientosDisponibles(Guid idVuelo) {
			return await _asiento
				.Where(x => x.Estado == 'D' && x.VueloId == idVuelo)
				.ToListAsync();
		}

		public Task UpdateAsync(Asiento obj) {
			_asiento.Update(obj);

			return Task.CompletedTask;
		}
	}
}
