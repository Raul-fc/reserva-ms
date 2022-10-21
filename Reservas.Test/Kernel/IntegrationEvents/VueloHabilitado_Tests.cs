using Sharedkernel.IntegrationEvents;
using System;
using Xunit;

namespace Reservas.Test.Kernel.IntegrationEvents {
	public class VueloHabilitado_Tests {
		[Fact]
		public void VueloHabilitado_CheckPropertiesValid() {
			var horaSalidaTest = DateTime.MinValue;
			var horaLLegadaTest = DateTime.MinValue;
			string estadoTest = null;
			var precioTest = 0;
			var fechaTest = DateTime.MinValue;
			var codRutaTest = Guid.NewGuid();
			var codDestinoTest = Guid.NewGuid();
			var codOrigenTest = Guid.NewGuid();
			var codAeronaveTest = Guid.NewGuid();
			var activoTest = 0;
			var stockAsientosTest = 0;
			var vueloIdTest = Guid.NewGuid();

			var objVuelo = new VueloHabilitado();

			Assert.Equal(DateTime.MinValue, objVuelo.horaSalida);
			Assert.Equal(DateTime.MinValue, objVuelo.horaLLegada);
			Assert.Null(objVuelo.estado);
			Assert.Equal(0, objVuelo.precio);
			Assert.Equal(DateTime.MinValue, objVuelo.fecha);
			Assert.Equal(Guid.Empty, objVuelo.codRuta);
			Assert.Equal(Guid.Empty, objVuelo.codDestino);
			Assert.Equal(Guid.Empty, objVuelo.codOrigen);
			Assert.Equal(Guid.Empty, objVuelo.codAeronave);
			Assert.Equal(0, objVuelo.activo);
			Assert.Equal(0, objVuelo.stockAsientos);
			Assert.Equal(Guid.Empty, objVuelo.vueloId);

			objVuelo.horaSalida = horaSalidaTest;
			objVuelo.horaLLegada = horaLLegadaTest;
			objVuelo.estado = estadoTest;
			objVuelo.precio = precioTest;
			objVuelo.fecha = fechaTest;
			objVuelo.codRuta = codRutaTest;
			objVuelo.codDestino = codDestinoTest;
			objVuelo.codOrigen = codOrigenTest;
			objVuelo.codAeronave = codAeronaveTest;
			objVuelo.activo = activoTest;
			objVuelo.stockAsientos = stockAsientosTest;
			objVuelo.vueloId = vueloIdTest;

			Assert.Equal(horaSalidaTest, objVuelo.horaSalida);
			Assert.Equal(horaLLegadaTest, objVuelo.horaLLegada);
			Assert.Equal(estadoTest, objVuelo.estado);
			Assert.Equal(precioTest, objVuelo.precio);
			Assert.Equal(fechaTest, objVuelo.fecha);
			Assert.Equal(codRutaTest, objVuelo.codRuta);
			Assert.Equal(codDestinoTest, objVuelo.codDestino);
			Assert.Equal(codOrigenTest, objVuelo.codOrigen);
			Assert.Equal(codAeronaveTest, objVuelo.codAeronave);
			Assert.Equal(activoTest, objVuelo.activo);
			Assert.Equal(stockAsientosTest, objVuelo.stockAsientos);
			Assert.Equal(vueloIdTest, objVuelo.vueloId);
		}
	}
}
