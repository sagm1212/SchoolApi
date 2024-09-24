using LeavesCinemaApi.Contracts.Models;
using LeavesCinemaApi.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SchoolsApi.Models;
using System;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly IMongoCollection<Teacher> _teachers;

        public TeacherRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoDBSettings:MongoDb").Value; 
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("MongoDBSettings:MongoDb", "La cadena de conexión de MongoDb no está configurada correctamente.");
            }

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Schooldb"); 
            _teachers = database.GetCollection<Teacher>("Teachers");        
        }

        public async Task AddTeacher(Teacher teacher)
        {
            try
            {
                await _teachers.InsertOneAsync(teacher);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el maestro: {ex.Message}");
                throw;
            }
        }

        public async Task<Teacher> GetTeacherByName(string name)
        {
            try
            {
                return await _teachers.Find<Teacher>(teacher => teacher.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el maestro: {ex.Message}");
                return null;
            }
        }
    }
}
