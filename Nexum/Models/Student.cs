namespace Nexum.Models
{
    public class Student
    {
        public Student(Guid id, int registration, string name, string lastName, string phone, DateTime dateBirth)
        {
            this.Id = id;
            this.Registration = registration;
            this.Name = name;
            this.LastName = lastName;
            this.Phone = phone;
            this.DateBirth = dateBirth;
        }

        public Guid Id { get; set; }

        public int Registration { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime DateBirth { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime? EndDate { get; set; } = null;

        public bool Status { get; set; } = true;

        public string Phone { get; set; }

        public IEnumerable<StudentDiscipline>? StudentsDisciplines { get; set; }
    }
}
