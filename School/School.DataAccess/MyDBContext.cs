using Microsoft.EntityFrameworkCore;
using School.DomainObjects;
using System;

namespace School.DataAccess
{
    /// <summary>
    /// Esta clase representa el punto de entrada, o la conexión a la base de datos.
    /// Hereda de DbContext, que pertenece a EF.
    /// 
    /// Implementa los patrones Repository y Unit Of Work.
    /// </summary>
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>()
                .HasIndex(s => s.StudentId) //...Tenga un indice en BD por la columna StduentId
                .IsUnique(); //...Y que sea unico. No admitira duplicados.

            //TODO: Revisar esta configuracion. Es una manera agregar atributos a la relacion N a N
            //Para este ejemplo, nos interasa la fecha que esta en la clase Enrollment
            //builder.Entity<Student>()
            //    .HasMany(u => u.Courses)     //Cada estudiante tiene muchos cursos....  
            //    .WithMany(g => g.Students)   //Cada curso tambien tiene muchos estudiantes...
            //    .UsingEntity<Enrollment>(    //Le indicamos a EF que use Enrollment como "join entity" 
            //        j => j.HasOne(x => x.Course).WithMany(g => g.Enrollments),
            //        j => j.HasOne(x => x.Student).WithMany(u => u.Enrollments));
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

    }
}
