namespace Nexum.Models
{
    public class StudentDiscipline
    {
        public StudentDiscipline(Guid studentId, Guid disciplineId)
        {
            StudentId = studentId;
            DisciplineId = disciplineId;
        }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public Guid DisciplineId { get; set; }

        public Discipline Discipline { get; set; }
    }
}
