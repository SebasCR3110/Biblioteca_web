using Biblioteca_web.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca_web.Infraestructura.Data.Configuraciones
{
    public class PrestadosConfiguracion : IEntityTypeConfiguration<Prestados>
    {
        public void Configure(EntityTypeBuilder<Prestados> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK__PRESTADO__3D43C4E0CC76A275");

            builder.ToTable("PRESTADOS");

            builder.Property(e => e.Id)
                .HasColumnName("ID_PRESTADO");

            builder.Property(e => e.Devuelto)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnName("DEVUELTO");

            builder.Property(e => e.FechaDevolucion)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("FECHA_DEVOLUCION");

            builder.Property(e => e.FechaPrestamo)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("FECHA_PRESTAMO");

            builder.Property(e => e.IdEstudiante).HasColumnName("ID_ESTUDIANTE");

            builder.Property(e => e.IdLibro).HasColumnName("ID_LIBRO");

            builder.HasOne(d => d.IdEstudianteNavigation)
                .WithMany(p => p.Prestados)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("FK__PRESTADOS__ID_ES__36B12243");

            builder.HasOne(d => d.IdLibroNavigation)
                .WithMany(p => p.Prestados)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK__PRESTADOS__ID_LI__37A5467C");
        }
    }
}
