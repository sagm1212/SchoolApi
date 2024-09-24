using LeavesCinemaApi.Contracts.Models;
using SchoolsApi.Models;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Infrastructure.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Task AddTeacher(Teacher teacher);
        Task<Teacher> GetTeacherByName(string name);
    }
}
