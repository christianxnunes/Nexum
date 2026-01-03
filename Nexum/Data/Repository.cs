using Microsoft.EntityFrameworkCore;
using Nexum.Models;

namespace Nexum.Data
{
    public class Repository : IRepository
    {
        private readonly NexumContext _nexumContext;

        public Repository(NexumContext nexumContext)
        {
            _nexumContext = nexumContext;
        }

        //Dynamic
        
        public void Add<T>(T entity) where T : class
        {
                _nexumContext.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _nexumContext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _nexumContext.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_nexumContext.SaveChanges() > 0);
        }

        //Students
        public Student[] GetStudents(bool isDiscipline = false)
        {
            IQueryable<Student> query = _nexumContext.Students;

            if(isDiscipline)
            {
                query = query.Include(s => s.StudentsDisciplines)
                    .ThenInclude(sd => sd.Discipline)
                    .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Name);

            return query.ToArray();
        }

        public Student GetStudentById(Guid id, bool isDiscipline)
        {
            IQueryable<Student> query = _nexumContext.Students;

            if (isDiscipline)
            {
                query = query.Include(s => s.StudentsDisciplines)
                    .ThenInclude(sd => sd.Discipline)
                    .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Name).Where(s => s.Id == id);

            return query.FirstOrDefault();
        }

        //StudentDependenci

        public Student[] GetStudentByDependenciId(Guid id, bool isDiscipline = false)
        {
            IQueryable<Student> query = _nexumContext.Students;

            if (isDiscipline)
            {
                query = query.Include(s => s.StudentsDisciplines)
                    .ThenInclude(sd => sd.Discipline)
                    .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Name).Where(s => s.StudentsDisciplines.Any(sd => sd.DisciplineId == id));

            return query.ToArray();
        }

        public Teacher[] GetTeacherByDependenciId(Guid id, bool isStudent = false)
        {
            IQueryable<Teacher> query = _nexumContext.Teachers;

            if (isStudent)
            {
                query = query.Include(t => t.Disciplines)
                    .ThenInclude(d => d.StudentsDisciplines)
                    .ThenInclude(sd => sd.Student);
            }

            query = query
                .AsNoTracking()
                .Where(t => t.Disciplines.Any(d => d.StudentsDisciplines.Any(sd => sd.StudentId == id)));

            return query.ToArray();
        }
    }
}
