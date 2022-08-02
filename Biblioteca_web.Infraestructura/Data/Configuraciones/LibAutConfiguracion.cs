using Biblioteca_web.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca_web.Infraestructura.Data.Configuraciones
{
    public class LibAutConfiguracion : IEntityTypeConfiguration<LibAut>
    {
        public void Configure(EntityTypeBuilder<LibAut> builder)
        {
            builder.HasNoKey();

            builder.ToTable("LIB_AUT");

            builder.Property(e => e.IdAutor).HasColumnName("ID_AUTOR");

            builder.Property(e => e.IdLibro).HasColumnName("ID_LIBRO");

            builder.HasOne(d => d.IdAutorNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdAutor)
                .HasConstraintName("FK__LIB_AUT__ID_AUTO__276EDEB3");

            builder.HasOne(d => d.IdLibroNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK__LIB_AUT__ID_LIBR__286302EC");
        }
    }
}
