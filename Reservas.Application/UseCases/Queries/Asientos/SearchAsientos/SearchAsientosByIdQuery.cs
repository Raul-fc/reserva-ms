using MediatR;
using Reservas.Application.Dto.Asiento;
using System;
using System.Collections.Generic;

namespace Reservas.Application.UseCases.Queries.Asientos.SearchAsientos {
	public class SearchAsientosByIdQuery : IRequest<ICollection<AsientoDto>> {
		public Guid idVuelo { get; set; }
	}
}
