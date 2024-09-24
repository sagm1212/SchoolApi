using LeavesCinemaApi.Contracts.Models;
using SchoolsApi.Models;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Core.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<bool> AddTeacher(Teacher teacher);
        Task<Teacher> GetTeacherByName(string name);
    }
}
