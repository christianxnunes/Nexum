namespace Nexum.Models
{
    public class Teacher
    {
        public Teacher(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public IEnumerable<Discipline>? Disciplines { get; set; }
    }
}
