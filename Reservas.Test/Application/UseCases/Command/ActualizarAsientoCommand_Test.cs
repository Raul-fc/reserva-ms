using Reservas.Application.UseCases.Command.Asientos.actualizarEstadoAsientosCommand;
using System;
using Xunit;

namespace Reservas.Test.Application.UseCases.Command {
	public class ActualizarAsientoCommand_Test {
		[Fact]
		public void IsRequest_Valid() {
			var NroReservaTest = "R-001";
			var EstadoTest = 'R';
			var command = new ActualizarAsientoCommand(NroReservaTest, EstadoTest);

			Assert.Equal(NroReservaTest, command.NroReserva);
			Assert.Equal(EstadoTest, command.Estado);
		}

		[Fact]
		public void TestConstructor_IsPrivate() {
			var command = (ActualizarAsientoCommand)Activator.CreateInstance(typeof(ActualizarAsientoCommand), true);
			Assert.Null(command.NroReserva);
		}
	}
}
