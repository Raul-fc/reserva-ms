using MassTransit;
using MediatR;
using Reservas.Domain.Event;
using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reservas.Application.UseCases.DomainEventHandler.Reserva {
	public class PublishIntegrationEventWhenReservaCreadoHandler : INotificationHandler<ConfirmedDomainEvent<ReservaCreado>> {
		private readonly IPublishEndpoint _publishEndpoint;

		public PublishIntegrationEventWhenReservaCreadoHandler(IPublishEndpoint publishEndpoint) {
			_publishEndpoint = publishEndpoint;
		}

		public async Task Handle(ConfirmedDomainEvent<ReservaCreado> notification, CancellationToken cancellationToken) {
			ICollection<Sharedkernel.IntegrationEvents.VueloReserva> VueloReserva = new List<Sharedkernel.IntegrationEvents.VueloReserva>();
			foreach (var item in notification.DomainEvent._vueloReserva)
			{
				Sharedkernel.IntegrationEvents.VueloReserva data = new Sharedkernel.IntegrationEvents.VueloReserva();
				data.Id = item.Id;
				data.Pasajero = item.Pasajero;
				data.NroDocumento = item.NroDocumento;
				data.Costo = item.Costo;
				VueloReserva.Add(data);
			}
			Sharedkernel.IntegrationEvents.VentaRegistrada evento = new Sharedkernel.IntegrationEvents.VentaRegistrada() {
				Id = notification.DomainEvent.Id,
				FechaVuelo = notification.DomainEvent.FechaVuelo,
				NroReserva = notification.DomainEvent.NroReserva,
				Costo = notification.DomainEvent.Costo,
				IdVuelo = notification.DomainEvent.IdVuelo,
				Activo = true,
				VueloReserva = VueloReserva
			};
			await _publishEndpoint.Publish<Sharedkernel.IntegrationEvents.VentaRegistrada>(evento);
		}
	}
}
