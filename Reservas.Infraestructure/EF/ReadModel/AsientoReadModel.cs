using System;

namespace Reservas.Infraestructure.EF.ReadModel {
	public class AsientoReadModel {
		public Guid Id { get; set; }
		public string NroAsiento { get; set; }
		public char Estado { get; set; }
		public Guid AvionId { get; set; }
		public Guid VueloId { get; set; }
	}
}
