using Microsoft.EntityFrameworkCore;
using Nexum.Models;

namespace Nexum.Data
{
    public class NexumContext : DbContext
    {
        public NexumContext(DbContextOptions<NexumContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<StudentDiscipline> StudentsDisciplines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Many to Many Relationship between Student and Discipline
            modelBuilder.Entity<StudentDiscipline>()
                .HasKey(sd => new { sd.StudentId, sd.DisciplineId });

            //Student guid
            var studentJohnId = Guid.NewGuid();
            var studentJaneId = Guid.NewGuid();
            var studentAliceId = Guid.NewGuid();

            //Teacher guid
            var teacherPauloId = Guid.NewGuid();
            var teacherMarcosId = Guid.NewGuid();
            var teacherLuizId = Guid.NewGuid();

            //Discipline guid
            var disciplinePortuguesId = Guid.NewGuid();
            var disciplineLibrasId = Guid.NewGuid();
            var disciplineMatematicaId = Guid.NewGuid();
            var disciplineInglesId = Guid.NewGuid();
            var disciplineCienciasId = Guid.NewGuid();

            modelBuilder.Entity<Student>()
                .HasData(new List<Student>() {
                    new Student(studentJohnId, "John", "Doe", "123-456-7890"),
                    new Student(studentJaneId, "Jane", "Smith", "987-654-3210"),
                    new Student(studentAliceId, "Alice", "Nunes", "555-555-5555")
                });

            modelBuilder.Entity<Teacher>()
                .HasData(new List<Teacher>() {
                    new Teacher(teacherPauloId, "Paulo"),
                    new Teacher(teacherMarcosId, "Marcos"),
                    new Teacher(teacherLuizId, "Luiz")
                });

            modelBuilder.Entity<Discipline>()
                .HasData(new List<Discipline>() {
                    new Discipline(disciplinePortuguesId, "Portugues", teacherPauloId),
                    new Discipline(disciplineLibrasId, "Libras", teacherPauloId),
                    new Discipline(disciplineMatematicaId, "Matemática",teacherMarcosId),
                    new Discipline(disciplineInglesId, "Ingles", teacherLuizId),
                    new Discipline(disciplineCienciasId, "Ciencias", teacherLuizId)
                });

            modelBuilder.Entity<StudentDiscipline>()
                .HasData(new List<StudentDiscipline>() {
                    new StudentDiscipline(studentJohnId, disciplinePortuguesId),
                    new StudentDiscipline(studentAliceId, disciplineLibrasId),
                    new StudentDiscipline(studentJaneId, disciplineMatematicaId),
                    new StudentDiscipline(studentAliceId, disciplineInglesId),
                    new StudentDiscipline(studentAliceId, disciplineCienciasId)
                });

        }
    }
}
