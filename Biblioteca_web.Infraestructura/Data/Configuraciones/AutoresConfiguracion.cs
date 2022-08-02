using Biblioteca_web.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca_web.Infraestructura.Data.Configuraciones
{
    public class AutoresConfiguracion : IEntityTypeConfiguration<Autores>
    {
        public void Configure(EntityTypeBuilder<Autores> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK__AUTORES__DA37C1370098B913");

            builder.ToTable("AUTORES");

            builder.Property(e => e.Id)
                .HasColumnName("ID_AUTOR");

            builder.Property(e => e.NacionalidadAutor)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("NACIONALIDAD_AUTOR");

            builder.Property(e => e.NombreAutor)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("NOMBRE_AUTOR");
        }
    }
}
