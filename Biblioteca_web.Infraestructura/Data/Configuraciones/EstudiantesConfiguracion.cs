using Biblioteca_web.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca_web.Infraestructura.Data.Configuraciones
{
    public class EstudiantesConfiguracion : IEntityTypeConfiguration<Estudiantes>
    {
        public void Configure(EntityTypeBuilder<Estudiantes> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK__ESTUDIAN__55980880ED1F9270");

            builder.ToTable("ESTUDIANTES");

            builder.HasIndex(e => e.CedulaIdentidad, "UQ__ESTUDIAN__1FF288CA2A73EEC4")
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("ID_ESTUDIANTE");

            builder.Property(e => e.CarreraEstudiante)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("CARRERA_ESTUDIANTE");

            builder.Property(e => e.CedulaIdentidad)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("CEDULA_IDENTIDAD");

            builder.Property(e => e.DireccionEstudiante)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("DIRECCION_ESTUDIANTE");

            builder.Property(e => e.EdadEstudiante)
                .IsRequired()
                .HasColumnName("EDAD_ESTUDIANTE");

            builder.Property(e => e.NombreEstudiante)
                .HasMaxLength(60)
                .HasColumnName("NOMBRE_ESTUDIANTE");
        }
    }
}
