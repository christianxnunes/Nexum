using Nexum.Models;

namespace Nexum.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        bool SaveChanges();

        //Students

        Student[] GetStudents(bool isDiscipline = false);

        Student GetStudentById(Guid id, bool isDiscipline = false);
        
        Student[] GetStudentByDependenciId(Guid id, bool isDiscipline = false);


        //Teacher
        Teacher[] GetTeacherByDependenciId(Guid id, bool isStudent = false);
    }
}
