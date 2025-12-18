namespace Nexum.Models
{
    public class Discipline
    {
        public Discipline(Guid id, string name, Guid teacherId)
        {
            Id = id;
            Name = name;
            TeacherId = teacherId;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public IEnumerable<StudentDiscipline> StudentsDisciplines { get; set; }
    }
}
