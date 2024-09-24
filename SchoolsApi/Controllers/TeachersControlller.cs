using LeavesCinemaApi.Contracts.Models;
using LeavesCinemaApi.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SchoolsApi.Models;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("register-teacher")]
        public async Task<IActionResult> Post([FromBody] Teacher request)
        {
            var result = await _teacherService.AddTeacher(request);
            if (result)
            {
                return Ok(new { Message = "Maestro registrado exitosamente" });
            }
            return StatusCode(500, new { Message = "Ha ocurrido un error" });
        }

        [HttpGet("teacher/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var teacher = await _teacherService.GetTeacherByName(name);
            if (teacher != null)
            {
                return Ok(teacher);
            }
            return NotFound(new { Message = "Maestro no encontrado" });
        }
    }
}
