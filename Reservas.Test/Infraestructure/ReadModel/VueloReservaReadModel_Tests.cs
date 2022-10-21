using Reservas.Infraestructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Infraestructure.ReadModel {
	public class VueloReservaReadModel_Tests {
		[Fact]
		public void VueloReservaReadModel_CheckPropertiesValid() {
			var idTest = Guid.NewGuid();
			var costoTest = 500;
			var nroDocumentoTest = "9620135";
			var activoTest = true;
			var pasajeroTest = "juan perez";


			var obj = new VueloReservaReadModel();
			obj.Id = idTest;
			obj.Costo = costoTest;
			obj.Activo = activoTest;
			obj.Pasajero = pasajeroTest;
			obj.NroDocumento = nroDocumentoTest;

			Assert.Equal(idTest, obj.Id);
			Assert.Equal(costoTest, obj.Costo);
			Assert.Equal(activoTest, obj.Activo);
			Assert.Equal(pasajeroTest, obj.Pasajero);
		}
	}
}
