namespace Nexum.Models
{
    public class Discipline
    {
        public Discipline(Guid id, string name, int teacherId)
        {
            Id = id;
            Name = name;
            TeacherId = teacherId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<StudentDiscipline> StudentsDisciplines { get; set; }
    }
}
