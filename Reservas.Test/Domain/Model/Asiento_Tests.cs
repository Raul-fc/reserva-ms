using Reservas.Domain.Model.Asientos;
using System;
using Xunit;

namespace Reservas.Test.Domain.Model {
	public class Asiento_Tests {
		[Fact]
		public void Asiento_CheckPropertiesValid() {
			var NroAsientoTest = "A-001";
			var AvionIdTest = Guid.NewGuid();
			var VueloIdTest = Guid.NewGuid();

			var obj = new Asiento(NroAsientoTest, AvionIdTest, VueloIdTest);

			Assert.Equal(NroAsientoTest, obj.NroAsiento);
			Assert.Equal(AvionIdTest, obj.AvionId);
			Assert.Equal(VueloIdTest, obj.VueloId);


			obj.AsientoAnulado();
			obj.AsientoCheckIn();
			obj.AsientoReservado();
			obj.AsientoVendido();
		}
		public void AsientoReservado_CheckPropertiesValid() {
			var NroAsientoTest = "A-001";
			var AvionIdTest = Guid.NewGuid();
			var VueloIdTest = Guid.NewGuid();

			var obj = new Asiento(NroAsientoTest, AvionIdTest, VueloIdTest);

			Assert.Equal(NroAsientoTest, obj.NroAsiento);
			Assert.Equal(AvionIdTest, obj.AvionId);
			Assert.Equal(VueloIdTest, obj.VueloId);


			obj.AsientoAnulado();
			obj.AsientoCheckIn();
			obj.AsientoReservado();

		}
	}
}
