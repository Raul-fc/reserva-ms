using Reservas.Application.Dto.Reserva;
using System;
using Xunit;

namespace Reservas.Test.Application.Dto {
	public class VueloReservaDto_Tests {
		[Fact]
		public void DetallePedidoDto_CheckPropertiesValid() {
			var pasajeroTest = "juan perez";
			var nroDocumentoTest = "9641205";
			decimal costoTest = new(450.0);

			var objVuelo = new VueloReservaDto();
			objVuelo.Pasajero = pasajeroTest;
			objVuelo.NroDocumento = nroDocumentoTest;
			objVuelo.Costo = costoTest;

			Assert.Equal(pasajeroTest, objVuelo.Pasajero);
			Assert.Equal(nroDocumentoTest, objVuelo.NroDocumento);
			Assert.Equal(costoTest, objVuelo.Costo);
		}

	}
}
