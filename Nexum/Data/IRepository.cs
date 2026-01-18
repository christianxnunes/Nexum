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

        Student[] GetStudents(bool isTeacher = false);

        Student GetStudentById(Guid id, bool isTeacher = false);
        
        Student[] GetStudentByDependenciId(Guid id, bool isTeacher = false);


        //Teacher
        Teacher[] GetTeacher(bool isStudent = false);

        Teacher GetTeacherById(Guid id, bool isStudent = false);

        Teacher[] GetTeacherByDependenciId(Guid id, bool isStudent = false);
    }
}
