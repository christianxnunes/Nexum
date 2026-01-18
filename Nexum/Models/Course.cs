namespace Nexum.Models
{
    public class Course
    {
        public Course(Guid id, string name) 
        {
            this.Id = id;
            this.Name = name;
        }


        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Discipline> Disciplines { get; set; }
    }
}
