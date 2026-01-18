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
        private readonly IRepository _repository;

        public StudentController(
            IRepository repository
         )
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var res = _repository.GetStudents(true);
            return Ok(res);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetStudentById(Guid id)
        {
            var student = _repository.GetStudentById(id, false);
            if (student == null) return NotFound("Aluno não foi encontrado!");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult PostStudent(Student student)
        {
            _repository.Add(student);
            if (_repository.SaveChanges()) return Ok(student);
            
            return BadRequest("Não foi possivel salvar aluno!");
        }

        [HttpPut("{id:guid}")]
        public IActionResult PutStudent(Guid id, Student student)
        {
            var existing = _repository.GetStudentById(id, false);
            if (existing == null) return NotFound("Aluno não foi encontrado!");
            
            _repository.Update(student);
            if (_repository.SaveChanges()) return Ok(student);

            return BadRequest("Não foi possivel editar aluno!");
        }

        [HttpPatch("{id:guid}")]
        public IActionResult PatchStudent(Guid id, Student student)
        {
            var existing = _repository.GetStudentById(id, false);
            if (existing == null) return NotFound("Aluno não foi encontrado!");

            _repository.Update(student);
            if (_repository.SaveChanges()) return Ok(student);

            return BadRequest("Não foi possivel editar aluno!");
        }

        [HttpDelete("{id}")]
        public IActionResult DelStudentById(Guid id)
        {
            var student = _repository.GetStudentById(id, false);
            if (student == null) return NotFound("Aluno não foi encontrado!");

            _repository.Delete(student);
            if (_repository.SaveChanges()) return Ok();

            return BadRequest("Não foi possivel deletar o aluno!");
        }
    }
}
