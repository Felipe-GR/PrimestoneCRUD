using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Curso> Courses { get; set; }
        public DbSet<Direccion> Addresses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<EstudianteCurso> Students_Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder tables)
        {
            tables.Entity<Curso>().ToTable("Courses");
            tables.Entity<Direccion>().ToTable("Addresses");
            tables.Entity<Student>().ToTable("Students");
            tables.Entity<EstudianteCurso>().ToTable("Students_Courses");
        }
    }
}
