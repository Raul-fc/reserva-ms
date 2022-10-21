using Sharedkernel.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Kernel.IntegrationEvents {
	public class VueloReserva_Tests {
		[Fact]
		public void VueloHabilitado_CheckPropertiesValid() {
			var IdTest = Guid.NewGuid();
			string pasajeroTest = null;
			string nroDocumentoTest = null;
			var costoTest = 0;

			var objVuelo = new VueloReserva();

			Assert.Equal(Guid.Empty, objVuelo.Id);
			Assert.Null(objVuelo.Pasajero);
			Assert.Null(objVuelo.NroDocumento);
			Assert.Equal(0, objVuelo.Costo);

			objVuelo.Id = IdTest;
			objVuelo.Pasajero = pasajeroTest;
			objVuelo.NroDocumento = nroDocumentoTest;
			objVuelo.Costo = costoTest;

			Assert.Equal(IdTest, objVuelo.Id);
			Assert.Equal(pasajeroTest, objVuelo.Pasajero);
			Assert.Equal(nroDocumentoTest, objVuelo.NroDocumento);
			Assert.Equal(costoTest, objVuelo.Costo);
		}
	}
}
