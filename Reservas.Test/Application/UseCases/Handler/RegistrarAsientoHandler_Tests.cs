using Microsoft.Extensions.Logging;
using Moq;
using Reservas.Application.UseCases.Command.Asientos.registrarAsientos;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Asientos;
using Reservas.Domain.Repositories;
using Sharedkernel.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Application.UseCases.Handler {
	public class RegistrarAsientoHandler_Tests {
		private readonly Mock<IAsientoRepository> _asientoRepository;
		private readonly Mock<ILogger<RegistrarAsientoHandler>> _logger;

		private readonly Mock<IAsientoFactory> _asientoFactory;
		private readonly Mock<IUnitOfWork> _unitOfWork;

		public RegistrarAsientoHandler_Tests() {
			_asientoRepository = new Mock<IAsientoRepository>();
			_logger = new Mock<ILogger<RegistrarAsientoHandler>>();
			_asientoFactory = new Mock<IAsientoFactory>();
			_unitOfWork = new Mock<IUnitOfWork>();

		}


		[Fact]
		public void RegistrarAsiento_Correctly() {

			var handler = new RegistrarAsientoHandler(
				_asientoRepository.Object,
				_logger.Object,
				_asientoFactory.Object,
				_unitOfWork.Object
				);

			var avionIdTest = Guid.NewGuid();
			var vueloIdTest = Guid.NewGuid();
			var nroAsientoTest = 1;

			var cmd = new RegistrarAsientoCommand(avionIdTest, vueloIdTest, nroAsientoTest);
			var tcs = new CancellationTokenSource(1000);
			var re = handler.Handle(cmd, tcs.Token);

			var objAsientos = cmd;
			for (int i = 0; i < objAsientos.NroAsientos; i++)
			{
				var _asientoTest = "A-001";
				var _avionIdTest = Guid.NewGuid();
				var _vueloIdTest = Guid.NewGuid();

				var asientoTest = new Asiento(_asientoTest, _avionIdTest, _vueloIdTest);

				var nroAsiento = "A-00" + i + 1;
				_asientoFactory.Setup(mock => mock.Create(nroAsiento, objAsientos.AvionId, objAsientos.VueloId))
				.Returns(asientoTest);

				_asientoRepository.Setup(mock => mock.CreateAsync(asientoTest))
					.Returns(Task.FromResult(asientoTest));


			}
		}
	}
}
