using LeavesCinemaApi.Contracts.Models;
using LeavesCinemaApi.Core.Services.Interfaces;
using LeavesCinemaApi.Infrastructure.Repositories.Interfaces;
using SchoolsApi.Models;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Core.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<bool> AddTeacher(Teacher teacher)
        {
            await _teacherRepository.AddTeacher(teacher);
            return true;
        }

        public async Task<Teacher> GetTeacherByName(string name)
        {
            return await _teacherRepository.GetTeacherByName(name);
        }
    }
}
