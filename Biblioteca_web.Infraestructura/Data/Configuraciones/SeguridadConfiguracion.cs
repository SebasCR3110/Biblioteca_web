using Biblioteca_web.Core.Entities;
using Biblioteca_web.Core.Enumeraciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Biblioteca_web.Infraestructura.Data.Configuraciones
{
    public class SeguridadConfiguracion : IEntityTypeConfiguration<Seguridad>
    {
        public void Configure(EntityTypeBuilder<Seguridad> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("SEGURIDAD");

            builder.Property(e => e.Id)
                .HasColumnName("ID_SEGURIDAD");

            builder.Property(e => e.Usuario)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("USUARIO");

            builder.Property(e => e.NombreUsuario)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NOMBRE_USUARIO");

            builder.Property(e => e.Contrasena)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("CONTRASENA");

            builder.Property(e => e.Rol)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("ROL")
                .HasConversion(
                x => x.ToString(),
                x => (TipoRol)Enum.Parse(typeof(TipoRol), x)
                );
        }
    }
}
