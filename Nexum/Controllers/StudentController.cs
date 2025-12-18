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

        public StudentController(
            NexumContext nexumContext
         )
        {
            _nexumContext = nexumContext;
        }


        [HttpGet]
        public IActionResult GetStudents()
        {
            if (_nexumContext.Students == null || !_nexumContext.Students.Any()) return NotFound("Nenhum aluno foi encontrado!");
            return Ok(_nexumContext.Students);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetStudentById(Guid id)
        {
            var student = _nexumContext.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound("Aluno não foi encontrado!");
            return Ok(student);
        }

        [HttpGet("{name}")]
        public IActionResult GetStudentByName(string name)
        {
            var student = _nexumContext.Students.FirstOrDefault(s => s.Name == name);
            if (student == null) return NotFound("Aluno não foi encontrado!");
            return Ok(student);
        }

        [HttpGet("list")]
        public IActionResult GetStudentByLastName(string lastName)
        {
            var student = _nexumContext.Students.FirstOrDefault(s => s.LastName == lastName);
            if (student == null) return NotFound("Aluno não foi encontrado!");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult PostStudent(Student student)
        {
            var existing = _nexumContext.Students.AsNoTracking().FirstOrDefault(s => s.Name == student.Name && s.LastName == student.LastName);
            if (existing != null) return NotFound("Aluno já existe!");
            _nexumContext.Add(student);
            _nexumContext.SaveChanges();
            return Ok(student);
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
