using Reservas.Domain.Event;
using System;
using Xunit;

namespace Reservas.Test.Domain.Event {
	public class ItemReservaAgregado_Tests {
		[Fact]
		public void ItemReservaAgreago_CheckPropertiesValid() {
			var pasajeroTest = "juan perez";
			var nroDocTest = "9649403";
			var costoTest = 200;

			var obj = new ItemReservaAgregado(
				pasajeroTest,
				nroDocTest,
				costoTest);

			Assert.Equal(pasajeroTest, obj.Pasajero);
			Assert.Equal(costoTest, obj.Costo);

		}
	}
}
