using Microsoft.Extensions.Logging;
using Moq;
using Reservas.Application.UseCases.Command.Asientos.actualizarCheckingCommand;
using Reservas.Application.UseCases.Command.Asientos.actualizarEstadoAsientosCommand;
using Reservas.Domain.Factories;
using Reservas.Domain.Model.Asientos;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Application.UseCases.Handler {
	public class ActualizarCheckinHandler_Tests {
		private readonly Mock<IAsientoRepository> _asientoRepository;
		private readonly Mock<IReservaRepository> _reservaRepository;
		private readonly Mock<ILogger<ActualizarAsientoHandler>> _logger;

		private readonly Mock<IAsientoFactory> _asientoFactory;
		private readonly Mock<IUnitOfWork> _unitOfWork;

		public ActualizarCheckinHandler_Tests() {
			_asientoRepository = new Mock<IAsientoRepository>();
			_reservaRepository = new Mock<IReservaRepository>();
			_logger = new Mock<ILogger<ActualizarAsientoHandler>>();
			_unitOfWork = new Mock<IUnitOfWork>();
			_asientoFactory = new Mock<IAsientoFactory>();
		}

		[Fact]
		public void ActualizarCheckinHandler_Correctly() {

			var handler = new ActualizarCheckinHandler(
				_asientoRepository.Object,
				_reservaRepository.Object,
				_logger.Object,
				_asientoFactory.Object,
				_unitOfWork.Object
				);

			var IdTest = Guid.NewGuid();
			var nroReservaTest = "R-001";
			var nroAsientoTest = "A-001";

			var cmd = new ActualizarCheckinCommand(IdTest, nroReservaTest, nroAsientoTest);
			var tcs = new CancellationTokenSource(1000);
			var re = handler.Handle(cmd, tcs.Token);



			var vueloIdTest = Guid.NewGuid();
			var fechaVueloTest = DateTime.Today;
			var avionId = Guid.NewGuid();
			var reservaTest = new Reserva(vueloIdTest, nroReservaTest, fechaVueloTest);
			var asientoTest = new Asiento(nroAsientoTest, avionId, vueloIdTest);
			var listAsientoTest = new List<Asiento>();
			listAsientoTest.Add(asientoTest);

			_reservaRepository.Setup(mock => mock.ObtReserva(cmd.NroReserva))
				.Returns(Task.FromResult(reservaTest));

			_asientoRepository.Setup(mock => mock.obtAsientosConEstadoVendido(reservaTest.IdVuelo))
				.Returns(Task.FromResult(listAsientoTest));

			var myAsiento = listAsientoTest[0];
			myAsiento.AsientoCheckIn();
			reservaTest.VentaCheckIn();

			_reservaRepository.Setup(mock => mock.UpdateAsync(reservaTest))
				.Returns(Task.FromResult(listAsientoTest));

			_asientoRepository.Setup(mock => mock.UpdateAsync(myAsiento));





		}
	}
}
