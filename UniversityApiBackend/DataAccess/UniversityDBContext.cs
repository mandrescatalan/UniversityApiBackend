using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.DataAccess
{
    public class UniversityDBContext:DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
        {

        }
        //Add DbSets (Tables of our Data base)
        public DbSet<User>? Users { get; set; }

        public DbSet<Curso>? Cursos { get; set; }

        public DbSet<Tema>? Temas { get; set; }

        public DbSet<Categoria>? Categorias { get; set; }

        public DbSet<Estudiante>? Estudiantes { get; set; }

    }
}
