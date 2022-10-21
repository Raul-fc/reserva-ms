using Reservas.Application.UseCases.Command.Asientos.actualizarCheckingCommand;
using System;
using Xunit;

namespace Reservas.Test.Application.UseCases.Command {
	public class ActualizarCheckinCommand_Test {
		[Fact]
		public void IsRequest_Valid() {
			var idTest = Guid.NewGuid();
			var nroReservaTest = "R-001";
			var nroAsientoTest = "A-001";

			var command = new ActualizarCheckinCommand(idTest, nroReservaTest, nroAsientoTest);

			Assert.Equal(idTest, command.Id);
			Assert.Equal(nroReservaTest, command.NroReserva);
			Assert.Equal(nroAsientoTest, command.NroAsiento);
		}

		[Fact]
		public void TestConstructor_IsPrivate() {
			var command = (ActualizarCheckinCommand)Activator.CreateInstance(typeof(ActualizarCheckinCommand), true);
			Assert.Equal(Guid.Empty, command.Id);
		}
	}
}
