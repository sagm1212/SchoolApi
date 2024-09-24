using LeavesCinemaApi.Contracts.Models;
using LeavesCinemaApi.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("register-student")]
        public async Task<IActionResult> Post([FromBody] Student request)
        {
            var result = await _studentService.AddStudent(request);
            if (result)
            {
                return Ok(new { Message = "Estudiante registrado exitosamente" });
            }
            return StatusCode(500, new { Message = "Ha ocurrido un error" });
        }

        [HttpGet("student/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var student = await _studentService.GetStudentAsync(id);
            if (student != null)
            {
                return Ok(student);
            }
            return NotFound(new { Message = "Estudiante no encontrado" });
        }

        [HttpDelete("delete-student/{document}")]
        public async Task<IActionResult> DeleteStudent(string document)
        {
            var result = await _studentService.DeleteStudentByDocument(document);
            if (result)
            {
                return Ok(new { Message = "Estudiante eliminado correctamente" });
            }
            return NotFound(new { Message = "Estudiante no encontrado para eliminar" });
        }
    }
}
