
using MassTransit;
using MediatR;
using Reservas.Application.UseCases.Command.Asientos.actualizarCheckingCommand;
using Sharedkernel.IntegrationEvents;
using System;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.Consumers {
	public class CheckinConfirmadoConsumer : IConsumer<Checkin> {
		private readonly IMediator _mediator;
		public const string ExchangeName = "checkin-realizado";
		public const string QueueName = "checkin-realizado-reserva";

		public CheckinConfirmadoConsumer(IMediator mediator) {
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<Checkin> context) {
			Checkin @event = context.Message;
			ActualizarCheckinCommand command = new ActualizarCheckinCommand(@event.id, @event.NroReserva, @event.NroAsiento);
			await _mediator.Send(command);
		}
	}
}
