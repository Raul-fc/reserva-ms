using Reservas.Application.Dto.Asiento;
using System;
using Xunit;

namespace Reservas.Test.Application.Dto {
	public class AsientoDto_Test {
		[Fact]
		public void AsientoDto_CheckPropertiesValid() {
			var IdTest = Guid.NewGuid();
			var VueloIdTest = Guid.NewGuid();
			var NroAsientoTest = "A-001";

			var objAsiento = new AsientoDto();

			Assert.Equal(Guid.Empty, objAsiento.Id);
			Assert.Equal(Guid.Empty, objAsiento.VueloId);
			Assert.Null(objAsiento.NroAsiento);

			objAsiento.Id = IdTest;
			objAsiento.VueloId = VueloIdTest;
			objAsiento.NroAsiento = NroAsientoTest;

			Assert.Equal(IdTest, objAsiento.Id);
			Assert.Equal(VueloIdTest, objAsiento.VueloId);
			Assert.Equal(NroAsientoTest, objAsiento.NroAsiento);
		}
	}
}
