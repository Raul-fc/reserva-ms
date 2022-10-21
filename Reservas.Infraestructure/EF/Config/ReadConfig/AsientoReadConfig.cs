using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Infraestructure.EF.ReadModel;
using System.Diagnostics.CodeAnalysis;

namespace Reservas.Infraestructure.EF.Config.ReadConfig {
	[ExcludeFromCodeCoverage]
	public class AsientoReadConfig : IEntityTypeConfiguration<AsientoReadModel> {
		public void Configure(EntityTypeBuilder<AsientoReadModel> builder) {
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

		}
	}
}
