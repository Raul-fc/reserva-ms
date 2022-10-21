using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Domain.Model.Asientos;
using System.Diagnostics.CodeAnalysis;

namespace Reservas.Infraestructure.EF.Config.WriteConfig {
	[ExcludeFromCodeCoverage]
	public class AsientoWriteConfig : IEntityTypeConfiguration<Asiento> {
		public void Configure(EntityTypeBuilder<Asiento> builder) {
			builder.ToTable("Asiento");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.NroAsiento)
				.HasColumnName("nroAsiento")
				.HasMaxLength(6);

			builder.Property(x => x.Estado)
				.HasColumnName("estado")
				.HasColumnType("char");

			builder.Property(x => x.AvionId)
				.HasColumnName("AvionId")
				.HasColumnType("uniqueidentifier");

			builder.Property(x => x.VueloId)
				.HasColumnName("VueloId")
				.HasColumnType("uniqueidentifier");

			builder.Ignore("_domainEvents");
			builder.Ignore(x => x.DomainEvents);
		}
	}
}
