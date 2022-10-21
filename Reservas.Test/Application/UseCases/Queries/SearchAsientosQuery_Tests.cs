using Reservas.Application.UseCases.Queries.Asientos.SearchAsientos;
using Xunit;

namespace Reservas.Test.Application.UseCases.Queries {
	public class SearchAsientosQuery_Tests {
		[Fact]
		public void SearchAsientosQuery_CheckPropertiesValid() {

			var obj = new SearchAsientosQuery();

			Assert.NotEqual("R-111", obj.NroReserva);
			Assert.NotEqual('D', obj.Estado);
		}
	}
}
