namespace Nexum.Models
{
    public class StudentCourse
    {
        public StudentCourse(Guid studentId, Guid courseId)
        {
            this.StudentId = studentId;
            this.CourseId = courseId;
        }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime EndDate { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public Guid CourseId { get; set; }

        public Course Courses { get; set; }
    }
}
