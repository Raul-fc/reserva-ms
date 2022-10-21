using MassTransit;
using MediatR;
using Reservas.Application.UseCases.Command.Asientos.registrarAsientos;
using Sharedkernel.IntegrationEvents;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Consumers {
	public class VueloRegistradoConsumer : IConsumer<VueloHabilitado> {
		private readonly IMediator _mediator;
		public const string ExchangeName = "vuelo-registrado-exchange";
		public const string QueueName = "vuelo-registrado-reserva";

		public VueloRegistradoConsumer(IMediator mediator) {
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<VueloHabilitado> context) {
			VueloHabilitado @event = context.Message;

			RegistrarAsientoCommand command = new RegistrarAsientoCommand(@event.codAeronave, @event.vueloId, @event.stockAsientos);

			await _mediator.Send(command);

		}
	}
}
