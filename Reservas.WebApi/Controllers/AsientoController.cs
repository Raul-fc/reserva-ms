using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservas.Application.UseCases.Queries.Asientos.SearchAsientos;
using System.Threading.Tasks;

namespace Reservas.WebApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class AsientoController : ControllerBase {
		private readonly IMediator _mediator;

		public AsientoController(IMediator mediator) {
			_mediator = mediator;
		}

		[Route("search")]
		[HttpGet]
		public async Task<IActionResult> Search([FromQuery] SearchAsientosQuery query) {
			var reservas = await _mediator.Send(query);

			if (reservas == null)
				return BadRequest();

			return Ok(reservas);
		}

		[Route("searchById")]
		[HttpPost]
		public async Task<IActionResult> SearchById([FromBody] SearchAsientosByIdQuery query) {
			var reservas = await _mediator.Send(query);

			if (reservas == null)
				return BadRequest();

			return Ok(reservas);
		}
	}
}
