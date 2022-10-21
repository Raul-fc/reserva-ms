using Reservas.Application.UseCases.Queries.Asientos.SearchAsientos;
using System;
using Xunit;

namespace Reservas.Test.Application.UseCases.Queries {
	public class SearchAsientosByIdQuery_tests {
		[Fact]
		public void SearchAsientosByIdQuery_CheckPropertiesValid() {

			var obj = new SearchAsientosByIdQuery();

			Assert.NotEqual(Guid.NewGuid(), obj.idVuelo);
		}
	}
}
