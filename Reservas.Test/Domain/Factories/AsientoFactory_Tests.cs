using Reservas.Domain.Factories;
using System;
using Xunit;

namespace Reservas.Test.Domain.Factories {
	public class AsientoFactory_Tests {
		[Fact]
		public void Create_Correctly() {
			var asientoTest = "A-001";
			var avionIdTest = Guid.NewGuid();
			var vueloIdTest = Guid.NewGuid();

			var factory = new AsientoFactory();
			var asiento = factory.Create(asientoTest, avionIdTest, vueloIdTest);

			Assert.NotNull(asiento);
			Assert.Equal(asientoTest, asiento.NroAsiento);
			Assert.Equal(avionIdTest, asiento.AvionId);
			Assert.Equal(vueloIdTest, asiento.VueloId);

		}
	}
}
