using MediatR;
using Microsoft.EntityFrameworkCore;
using Reservas.Application.Dto.Asiento;
using Reservas.Application.UseCases.Queries.Asientos.SearchAsientos;
using Reservas.Infraestructure.EF.Contexts;
using Reservas.Infraestructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Infraestructure.EF.UseCases.Queries.Asientos {
	public class SearchAsientosbyIdHandler :
		IRequestHandler<SearchAsientosByIdQuery, ICollection<AsientoDto>> {
		private readonly DbSet<ReservaReadModel> _reservas;
		private readonly DbSet<AsientoReadModel> _asientos;

		public SearchAsientosbyIdHandler(ReadDbContext context) {
			_reservas = context.Reserva;
			_asientos = context.Asientos;
		}

		public async Task<ICollection<AsientoDto>> Handle(SearchAsientosByIdQuery request, CancellationToken cancellationToken) {

			var asientoList = await _asientos
							.AsNoTracking()
							.Where(x => x.VueloId == request.idVuelo)
							.ToListAsync();

			var result = new List<AsientoDto>();
			foreach (var objAsiento in asientoList)
			{
				var asientoDto = new AsientoDto() {
					VueloId = objAsiento.VueloId,
					NroAsiento = objAsiento.NroAsiento,
					Estado = objAsiento.Estado,
				};

				result.Add(asientoDto);
			}

			return result;
		}
	}
}
