using Reservas.Application.UseCases.Command.Asientos.registrarAsientos;
using System;
using Xunit;

namespace Reservas.Test.Application.UseCases.Command {
	public class RegistrarAsientoCommand_Tests {
		[Fact]
		public void IsRequest_Valid() {
			var avionidTest = Guid.NewGuid();
			var vueloidTest = Guid.NewGuid();
			var nroAsientoTest = 10;
			var command = new RegistrarAsientoCommand(avionidTest, vueloidTest, nroAsientoTest);

			Assert.Equal(avionidTest, command.AvionId);
			Assert.Equal(vueloidTest, command.VueloId);
			Assert.Equal(nroAsientoTest, command.NroAsientos);
		}

		[Fact]
		public void TestConstructor_IsPrivate() {
			var command = (RegistrarAsientoCommand)Activator.CreateInstance(typeof(RegistrarAsientoCommand), true);
			Assert.Equal(Guid.Empty, command.AvionId);
			Assert.Equal(Guid.Empty, command.VueloId);
		}
	}
}
