using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexum.Data;
using Nexum.Models;

namespace Nexum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly NexumContext _nexumContext;
        private readonly IRepository _repository;

        public StudentController(
            NexumContext nexumContext,
            IRepository repository
         )
        {
            _nexumContext = nexumContext;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_repository.GetStudents());
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetStudentById(Guid id)
        {
            var student = _repository.GetStudentByDependenciId(id);
            if (student == null) return NotFound("Aluno não foi encontrado!");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult PostStudent(Student student)
        {
            var existing = _nexumContext.Students.AsNoTracking().FirstOrDefault(s => s.Name == student.Name && s.LastName == student.LastName);
            if (existing != null) return NotFound("Aluno já existe!");
            _repository.Add(student);
            if(_repository.SaveChanges()) return Ok(student);
            
            return BadRequest("Não foi possivel salvar aluno!");
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(Guid id, Student student)
        {
            var existing = _nexumContext.Students.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (existing == null) return NotFound("Aluno não foi encontrado!");
            _nexumContext.Update(student);
            _nexumContext.SaveChanges();
            return Ok(student);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchStudent(Guid id, Student student)
        {
            var existing = _nexumContext.Students.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (existing == null) return NotFound("Aluno não foi encontrado!");
            _nexumContext.Update(student);
            _nexumContext.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DelStudentById(Guid id)
        {
            var student = _nexumContext.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound("Aluno não foi encontrado!");
            _nexumContext.Remove(student);
            _nexumContext.SaveChanges();
            return Ok();
        }
    }
}
