using Reservas.Domain.Event;
using Reservas.Domain.ValueObjects;
using Sharedkernel.Core;
using System;

namespace Reservas.Domain.Model.Pagos {
	public class Pago : AggregateRoot<Guid> {
		public DateTime Fecha { get; private set; }
		public PrecioValue Importe { get; private set; }
		public PrecioValue ImportePagado { get; private set; }
		public Guid ReservaId { get; private set; }

		private Pago() { }
		public Pago(Guid reservaId, decimal importe, decimal importePagado) {
			Id = Guid.NewGuid();
			ReservaId = reservaId;
			Fecha = DateTime.Now;
			Importe = importe;
			ImportePagado = importePagado;
		}

		public bool ValidadPago(decimal importeTotal, decimal importePagado) {
			var porcentaje = importeTotal / 2;
			if (importePagado < porcentaje)
			{
				throw new BussinessRuleValidationException($"Tiene que depositar al menos 50% del monto: { porcentaje } Bs");
			}

			if (importePagado > importeTotal)
			{
				throw new BussinessRuleValidationException($"Su saldo a cancelar es de {importeTotal}");
			}
			return true;
		}

		public (string, decimal) ObtTipoandImporteDado(decimal importeTotal, decimal importeACancelar, decimal totalPagado) {
			string tipo = "Recibo";
			decimal importeDado = 0;
			decimal SaldoACancelar = importeTotal - totalPagado;

			if (importeTotal == importeACancelar)
			{
				tipo = "Factura";
			}
			else
			{
				if (totalPagado == 0)
				{
					importeDado = importeTotal;
					tipo = "Recibo";
					ValidadPago(importeTotal, importeACancelar);
				}
				else
				{
					decimal totalDado = totalPagado + importeACancelar;
					if (importeTotal == totalDado)
					{
						tipo = "Factura";
					}
					else
					{
						if (totalDado > importeTotal)
						{

							throw new BussinessRuleValidationException($"1Su saldo a cancelar es de {SaldoACancelar}");
						}

						if (importeACancelar <= 0)
						{
							throw new BussinessRuleValidationException($"2Su saldo a cancelar es de {SaldoACancelar}");
						}
						importeDado = importeTotal - totalPagado;
					}

				}
			}

			return (tipo, importeDado);


		}



		public void ConsolidarPago(Guid ReservaId, decimal importeDado, string tipo) {
			var evento = new PagoRegistrado(Id, ReservaId, Importe, importeDado, ImportePagado, tipo);
			AddDomainEvent(evento);
		}
	}
}
