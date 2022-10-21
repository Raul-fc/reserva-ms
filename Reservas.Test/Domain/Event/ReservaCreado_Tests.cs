using Reservas.Domain.Event;
using Reservas.Domain.Model.Reservas;
using System;
using System.Collections.Generic;
using Xunit;

namespace Reservas.Test.Domain.Event {
	public class ReservaCreado_Tests {
		[Fact]
		public void ReservaCreado_CheckPropertiesValid() {
			var reservaIdTest = Guid.NewGuid();
			var fechaVuelo = DateTime.Now;
			var nroReservaTest = "R-1111";
			var costoTest = 500;
			var idVueloTest = Guid.NewGuid();
			ICollection<VueloReserva> _vueloReserva = null;

			var obj = new ReservaCreado(
				reservaIdTest,
				fechaVuelo,
				nroReservaTest,
				costoTest,
				idVueloTest,
				_vueloReserva);

			Assert.Equal(reservaIdTest, obj.ReservaId);
			Assert.Equal(nroReservaTest, obj.NroReserva);
			Assert.Equal(fechaVuelo, obj.FechaVuelo);
			Assert.Equal(costoTest, obj.Costo);
			Assert.Equal(idVueloTest, obj.IdVuelo);
			Assert.Null(obj._vueloReserva);

		}
	}
}
