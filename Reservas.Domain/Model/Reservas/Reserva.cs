using Reservas.Domain.Event;
using Reservas.Domain.Model.Reservas.ValueObjects;
using Reservas.Domain.ValueObjects;
using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Reservas.Domain.Model.Reservas {
	public class Reserva : AggregateRoot<Guid> {
		public Guid IdVuelo { get; private set; }
		public NumeroReserva NroReserva { get; private set; }
		public PrecioValue Costo { get; private set; }
		public DateTime Fecha { get; private set; }
		public DateTime FechaVuelo { get; private set; }
		public TimeSpan Hora { get; private set; }
		public TimeSpan HoraLimite { get; private set; }
		public char Estado { get; private set; }
		public bool Activo { get; private set; }

		private readonly ICollection<VueloReserva> _vueloReserva;

		public IReadOnlyCollection<VueloReserva> VueloReserva {
			get {
				return new ReadOnlyCollection<VueloReserva>(_vueloReserva.ToList());
			}
		}
		private Reserva() { }
		public Reserva(Guid idVuelo, string nroReserva, DateTime fechaVuelo) {
			DateTime horaActual = DateTime.Now;
			DateTime horaLimite = horaActual.AddHours(2);


			Id = Guid.NewGuid();
			IdVuelo = idVuelo;
			NroReserva = nroReserva;
			Costo = new PrecioValue(0m);
			Fecha = DateTime.Now;
			FechaVuelo = fechaVuelo;
			Hora = TimeSpan.Parse(horaActual.ToString("HH:mm"));
			HoraLimite = TimeSpan.Parse(horaLimite.ToString("HH:mm"));
			Estado = 'R';
			Activo = true;
			_vueloReserva = new List<VueloReserva>();
		}

		public void AgregarItem(string pasajero, string nroDocumento, decimal costo) {
			var detalleReserva = _vueloReserva.FirstOrDefault(x => x.NroDocumento == nroDocumento);
			if (detalleReserva is null)
			{
				detalleReserva = new VueloReserva(pasajero, nroDocumento, costo);
				_vueloReserva.Add(detalleReserva);
			}
			else
			{
				detalleReserva.ModificarReserva(pasajero, nroDocumento, costo);
			}
			Costo += costo;
			AddDomainEvent(new ItemReservaAgregado(pasajero, nroDocumento, Costo));
		}

		public void AnularReserva() {
			Estado = 'A';
			Activo = false;
		}

		public void VentaReserva() {
			Estado = 'V';
		}

		public void VentaCheckIn() {
			Estado = 'C';
		}
		public void ConsolidarReserva() {
			var evento = new ReservaCreado(Id, FechaVuelo, NroReserva, Costo, IdVuelo, _vueloReserva);
			AddDomainEvent(evento);
		}

	}
}
