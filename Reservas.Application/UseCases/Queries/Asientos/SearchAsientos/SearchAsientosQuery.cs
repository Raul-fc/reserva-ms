using MediatR;
using Reservas.Application.Dto.Asiento;
using System.Collections.Generic;

namespace Reservas.Application.UseCases.Queries.Asientos.SearchAsientos {
	public class SearchAsientosQuery : IRequest<ICollection<AsientoDto>> {
		public string NroReserva { get; set; }
		public char Estado { get; set; }
	}
}
