using Biblioteca_web.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca_web.Infraestructura.Data.Configuraciones
{
    public class LibrosConfiguracion : IEntityTypeConfiguration<Libros>
    {
        public void Configure(EntityTypeBuilder<Libros> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK__LIBROS__93FF0A067437006B");

            builder.ToTable("LIBROS");

            builder.Property(e => e.Id)
                .HasColumnName("ID_LIBRO");

            builder.Property(e => e.AreaLibro)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("AREA_LIBRO");

            builder.Property(e => e.EditorialLibro)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("EDITORIAL_LIBRO");

            builder.Property(e => e.TituloLibro)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("TITULO_LIBRO");
        }
    }
}
