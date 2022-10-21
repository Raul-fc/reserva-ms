using Sharedkernel.IntegrationEvents;
using System;
using Xunit;

namespace Reservas.Test.Kernel.IntegrationEvents {
	public class Checkin_Tests {
		[Fact]
		public void Checkin_CheckPropertiesValid() {
			var IdTest = Guid.NewGuid();
			var NroReservaTest = "R-001";
			var NroAsientoTest = "A-001";

			var objCheckin = new Checkin();

			Assert.Equal(Guid.Empty, objCheckin.id);
			Assert.Null(objCheckin.NroReserva);
			Assert.Null(objCheckin.NroAsiento);

			objCheckin.id = IdTest;
			objCheckin.NroReserva = NroReservaTest;
			objCheckin.NroAsiento = NroAsientoTest;

			Assert.Equal(IdTest, objCheckin.id);
			Assert.Equal(NroReservaTest, objCheckin.NroReserva);
			Assert.Equal(NroAsientoTest, objCheckin.NroAsiento);
		}
	}
}
