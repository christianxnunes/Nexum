namespace Nexum.Models
{
    public class Student
    {
        public Student(Guid id, string name, string lastName, string phone)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Phone = phone;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public IEnumerable<StudentDiscipline> StudentsDisciplines { get; set; }
    }
}
