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
        private readonly NexumContext _nexumContext;

        public TeacherController(
            NexumContext nexumContext
         )
        {
            _nexumContext = nexumContext;
        }

        [HttpGet]
        public IActionResult GetTeacher()
        {
            if (_nexumContext.Teachers == null || !_nexumContext.Teachers.Any()) return NotFound("Nenhum professor foi encontrado!");
            return Ok(_nexumContext.Teachers);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetTeacherById(Guid id)
        {
            var student = _nexumContext.Teachers.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound("Professor não foi encontrado!");
            return Ok(student);
        }

        [HttpGet("{name}")]
        public IActionResult GetTeacherByName(string name)
        {
            var student = _nexumContext.Teachers.FirstOrDefault(s => s.Name == name);
            if (student == null) return NotFound("Professor não foi encontrado!");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult PostTeacher(Teacher teacher)
        {
            var existing = _nexumContext.Teachers.AsNoTracking().FirstOrDefault(t => t.Name == teacher.Name);
            if (existing != null) return NotFound("Professor já existe!");
            _nexumContext.Add(teacher);
            _nexumContext.SaveChanges();
            return Ok(teacher);
        }

        [HttpPut("{id}")]
        public IActionResult PutTeacher(Guid id, Teacher teacher)
        {
            var existing = _nexumContext.Teachers.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (existing == null) return NotFound("Professor não foi encontrado!");
            _nexumContext.Update(teacher);
            _nexumContext.SaveChanges();
            return Ok(teacher);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchTeacher(Guid id, Teacher teacher)
        {
            var existing = _nexumContext.Teachers.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (existing == null) return NotFound("Professor não foi encontrado!");
            _nexumContext.Update(teacher);
            _nexumContext.SaveChanges();
            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public IActionResult DelTeacherById(Guid id)
        {
            var teacher = _nexumContext.Teachers.FirstOrDefault(s => s.Id == id);
            if (teacher == null) return NotFound("Professor não foi encontrado!");
            _nexumContext.Remove(teacher);
            _nexumContext.SaveChanges();
            return Ok();
        }
    }
}
