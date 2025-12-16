using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexum.Models;

namespace Nexum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public List<Student> Students = new List<Student>()
        {
            new Student(Guid.Parse("c379310f-2ed7-43e5-8845-8c1b28c692bb"), "John", "Doe", "123-456-7890"),
            new Student(Guid.Parse("640207bc-a8fe-4c14-934e-560eaf63be58"), "Jane", "Smith", "987-654-3210"),
            new Student(Guid.Parse("72302764-b6db-4655-babd-5d1dd5328609"), "Alice", "Johnson", "555-555-5555")
        };

        public StudentController() { }

        [HttpGet]
        public IActionResult GetStudents()
        {
            if (Students == null || !Students.Any()) return NotFound("Nenhum aluno foi encontrado!");
            return Ok(Students);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetStudentById(Guid id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound("Aluno não foi encontrado!");
            return Ok(student);
        }

        [HttpGet("{name}")]
        public IActionResult GetStudentByName(string name)
        {
            var student = Students.FirstOrDefault(s => s.Name == name);
            if (student == null) return NotFound("Aluno não foi encontrado!");
            return Ok(student);
        }

        [HttpGet("list")]
        public IActionResult GetStudentByLastName(string lastName)
        {
            var student = Students.FirstOrDefault(s => s.LastName == lastName);
            if (student == null) return NotFound("Aluno não foi encontrado!");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult PostStudent(Student student)
        {
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(Guid id, Student student)
        {
            if (id == null) return NotFound("Aluno não foi encontrado!");
            return Ok(student);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchStudent(Guid id, Student student)
        {
            if (id == null) return NotFound("Aluno não foi encontrado!");
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DelStudentById(Guid id)
        {
            if (id == null) return NotFound("Aluno não foi encontrado!");
            return Ok($"Aluno {id} foi removido com sucesso!");
        }
    }
}
