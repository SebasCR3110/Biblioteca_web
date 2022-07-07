using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Biblioteca_web.Core.Entities;

#nullable disable

namespace Biblioteca_web.Infraestructura.Data
{
    public partial class BIBLIOTECAContext : DbContext
    {
        public BIBLIOTECAContext()
        {
        }

        public BIBLIOTECAContext(DbContextOptions<BIBLIOTECAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autores> Autores { get; set; }
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<LibAut> LibAuts { get; set; }
        public virtual DbSet<Libros> Libros { get; set; }
        public virtual DbSet<Prestados> Prestados { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Autores>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK__AUTORES__DA37C1370098B913");

                entity.ToTable("AUTORES");

                entity.Property(e => e.IdAutor).HasColumnName("ID_AUTOR");

                entity.Property(e => e.NacionalidadAutor)
                    .HasMaxLength(20)
                    .HasColumnName("NACIONALIDAD_AUTOR");

                entity.Property(e => e.NombreAutor)
                    .HasMaxLength(60)
                    .HasColumnName("NOMBRE_AUTOR");
            });

            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__ESTUDIAN__55980880ED1F9270");

                entity.ToTable("ESTUDIANTES");

                entity.HasIndex(e => e.CedulaIdentidad, "UQ__ESTUDIAN__1FF288CA2A73EEC4")
                    .IsUnique();

                entity.Property(e => e.IdEstudiante).HasColumnName("ID_ESTUDIANTE");

                entity.Property(e => e.CarreraEstudiante)
                    .HasMaxLength(60)
                    .HasColumnName("CARRERA_ESTUDIANTE");

                entity.Property(e => e.CedulaIdentidad)
                    .HasMaxLength(11)
                    .HasColumnName("CEDULA_IDENTIDAD");

                entity.Property(e => e.DireccionEstudiante)
                    .HasMaxLength(80)
                    .HasColumnName("DIRECCION_ESTUDIANTE");

                entity.Property(e => e.EdadEstudiante).HasColumnName("EDAD_ESTUDIANTE");

                entity.Property(e => e.NombreEstudiante)
                    .HasMaxLength(60)
                    .HasColumnName("NOMBRE_ESTUDIANTE");
            });

            modelBuilder.Entity<LibAut>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LIB_AUT");

                entity.Property(e => e.IdAutor).HasColumnName("ID_AUTOR");

                entity.Property(e => e.IdLibro).HasColumnName("ID_LIBRO");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("FK__LIB_AUT__ID_AUTO__276EDEB3");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdLibro)
                    .HasConstraintName("FK__LIB_AUT__ID_LIBR__286302EC");
            });

            modelBuilder.Entity<Libros>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PK__LIBROS__93FF0A067437006B");

                entity.ToTable("LIBROS");

                entity.Property(e => e.IdLibro).HasColumnName("ID_LIBRO");

                entity.Property(e => e.AreaLibro)
                    .HasMaxLength(20)
                    .HasColumnName("AREA_LIBRO");

                entity.Property(e => e.EditorialLibro)
                    .HasMaxLength(30)
                    .HasColumnName("EDITORIAL_LIBRO");

                entity.Property(e => e.TituloLibro)
                    .HasMaxLength(40)
                    .HasColumnName("TITULO_LIBRO");
            });

            modelBuilder.Entity<Prestados>(entity =>
            {
                entity.HasKey(e => e.IdPrestado)
                    .HasName("PK__PRESTADO__3D43C4E0CC76A275");

                entity.ToTable("PRESTADOS");

                entity.Property(e => e.IdPrestado).HasColumnName("ID_PRESTADO");

                entity.Property(e => e.Devuelto)
                    .HasMaxLength(2)
                    .HasColumnName("DEVUELTO");

                entity.Property(e => e.FechaDevolucion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_DEVOLUCION");

                entity.Property(e => e.FechaPrestamo)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_PRESTAMO");

                entity.Property(e => e.IdEstudiante).HasColumnName("ID_ESTUDIANTE");

                entity.Property(e => e.IdLibro).HasColumnName("ID_LIBRO");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Prestados)
                    .HasForeignKey(d => d.IdEstudiante)
                    .HasConstraintName("FK__PRESTADOS__ID_ES__36B12243");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.Prestados)
                    .HasForeignKey(d => d.IdLibro)
                    .HasConstraintName("FK__PRESTADOS__ID_LI__37A5467C");
            });

        }

    }
}
