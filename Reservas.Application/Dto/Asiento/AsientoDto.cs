using System;

namespace Reservas.Application.Dto.Asiento {
	public class AsientoDto {
		public Guid Id { get; set; }
		public Guid VueloId { get; set; }
		public string NroAsiento { get; set; }
		public char Estado { get; set; }
	}
}
