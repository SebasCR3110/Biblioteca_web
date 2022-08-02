using Microsoft.EntityFrameworkCore;
using Biblioteca_web.Core.Entities;
using System.Reflection;

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
        public virtual DbSet<Seguridad> Seguridades { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
