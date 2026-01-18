namespace Nexum.Models
{
    public class Discipline
    {
        public Discipline(Guid id, string name, Guid teacherId, Guid courseId)
        {
            this.Id = id;
            this.Name = name;
            this.TeacherId = teacherId;
            this.CourseId = courseId;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int LoadHours { get; set; }

        public Guid? PrerequisiteId { get; set; } = null;

        public Discipline Prerequisite { get; set; }

        public Guid TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public Guid CourseId { get; set; }

        public Course Courses { get; set; }

        public IEnumerable<StudentDiscipline> StudentsDisciplines { get; set; }
    }
}
