using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexum.Data;
using Nexum.Models;

namespace Nexum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IRepository _repository;

        public TeacherController(
            IRepository repository
         )
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetTeacher()
        {
            var res = _repository.GetTeacher(true);
            return Ok(res);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetTeacherById(Guid id)
        {
            var teacher = _repository.GetTeacherById(id, false);
            if (teacher == null) return NotFound("Professor não foi encontrado!");
            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult PostTeacher(Teacher teacher)
        {
            _repository.Add(teacher);
            if (_repository.SaveChanges()) return Ok(teacher);

            return BadRequest("Não foi possivel salvar o professor!");
        }

        [HttpPut("{id:guid}")]
        public IActionResult PutTeacher(Guid id, Teacher teacher)
        {
            var existing = _repository.GetTeacherById(id, false);
            if (existing == null) return NotFound("Professor não foi encontrado!");
            
            _repository.Update(teacher);
            if(_repository.SaveChanges()) return Ok(teacher);

            return BadRequest("Não foi possivel editar o professor!");
        }

        [HttpPatch("{id:guid}")]
        public IActionResult PatchTeacher(Guid id, Teacher teacher)
        {
            var existing = _repository.GetTeacherById(id, false);
            if (existing == null) return NotFound("Professor não foi encontrado!");

            _repository.Update(teacher);
            if (_repository.SaveChanges()) return Ok(teacher);

            return BadRequest("Não foi possivel editar o professor!");
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DelTeacherById(Guid id)
        {
            var teacher = _repository.GetTeacherById(id, false);
            if (teacher == null) return NotFound("Professor não foi encontrado!");
            _repository.Delete(teacher);
            if (_repository.SaveChanges()) return Ok();

            return BadRequest("Não foi possivel deletar o professor!");
        }
    }
}
