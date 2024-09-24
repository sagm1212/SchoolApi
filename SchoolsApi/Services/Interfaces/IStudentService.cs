using LeavesCinemaApi.Contracts.Models;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Core.Services.Interfaces
{
    public interface IStudentService
    {
        Task<bool> AddStudent(Student student);
        Task<Student> GetStudentAsync(string id);
        Task<bool> DeleteStudentByDocument(string document);
    }
}
