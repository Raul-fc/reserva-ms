using Sharedkernel.IntegrationEvents;
using System;
using Xunit;

namespace Reservas.Test.Kernel.IntegrationEvents {
	public class VentaRegistrada_Tests {
		[Fact]
		public void VentaRegistrada_CheckPropertiesValid() {
			var IdTest = Guid.NewGuid();
			var NroReservaTest = "R-001";
			var CostoTest = 0;
			var FechaVueloTest = DateTime.MinValue;
			var IdVueloTest = Guid.NewGuid();
			var ActivoTest = false;

			var objVenta = new VentaRegistrada();

			Assert.Equal(Guid.Empty, objVenta.Id);
			Assert.Null(objVenta.NroReserva);
			Assert.Equal(0, objVenta.Costo);
			Assert.Equal(DateTime.MinValue, objVenta.FechaVuelo);
			Assert.Equal(Guid.Empty, objVenta.IdVuelo);
			Assert.False(objVenta.Activo);

			objVenta.Id = IdTest;
			objVenta.NroReserva = NroReservaTest;
			objVenta.Costo = CostoTest;
			objVenta.FechaVuelo = FechaVueloTest;
			objVenta.IdVuelo = IdVueloTest;
			objVenta.Activo = ActivoTest;

			Assert.Equal(IdTest, objVenta.Id);
			Assert.Equal(NroReservaTest, objVenta.NroReserva);
			Assert.Equal(CostoTest, objVenta.Costo);
			Assert.Equal(FechaVueloTest, objVenta.FechaVuelo);
			Assert.Equal(IdVueloTest, objVenta.IdVuelo);
			Assert.Equal(ActivoTest, objVenta.Activo);
		}
	}
}
