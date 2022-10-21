using MediatR;
using Microsoft.EntityFrameworkCore;
using Reservas.Application.Dto.Asiento;
using Reservas.Application.UseCases.Queries.Asientos.SearchAsientos;
using Reservas.Infraestructure.EF.Contexts;
using Reservas.Infraestructure.EF.ReadModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.UseCases.Queries.Asientos {
	public class SearchAsientosHandler :
		IRequestHandler<SearchAsientosQuery, ICollection<AsientoDto>> {

		private readonly DbSet<ReservaReadModel> _reservas;
		private readonly DbSet<AsientoReadModel> _asientos;

		public SearchAsientosHandler(ReadDbContext context) {
			_reservas = context.Reserva;
			_asientos = context.Asientos;
		}

		public async Task<ICollection<AsientoDto>> Handle(SearchAsientosQuery request, CancellationToken cancellationToken) {

			var objReserva = await _reservas
				.Where(u => u.Activo)
				.FirstOrDefaultAsync(u => u.NroReserva == request.NroReserva);

			var asientoList = await _asientos
							.AsNoTracking()
							.Where(x => x.VueloId == objReserva.IdVuelo && x.Estado == request.Estado)
							.ToListAsync();

			var result = new List<AsientoDto>();
			foreach (var objAsiento in asientoList)
			{
				var asientoDto = new AsientoDto() {
					Id = objReserva.Id,
					VueloId = objAsiento.VueloId,
					NroAsiento = objAsiento.NroAsiento
				};

				result.Add(asientoDto);
			}

			return result;
		}
	}
}
