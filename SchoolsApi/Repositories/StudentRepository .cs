using LeavesCinemaApi.Contracts.Models;
using LeavesCinemaApi.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace LeavesCinemaApi.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IMongoCollection<Student> _students;

        public StudentRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoDBSettings:MongoDb").Value;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("MongoDBSettings:MongoDb", "La cadena de conexión de MongoDb no está configurada correctamente.");
            }

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Schooldb");
            _students = database.GetCollection<Student>("Students");
        }

        public async Task AddStudent(Student student)
        {
            try
            {
                
                await _students.InsertOneAsync(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el estudiante: {ex.Message}");
                throw;
            }
        }

        public async Task<Student> GetStudent(string id)
        {
            try
            {
                
                if (ObjectId.TryParse(id, out var objectId))
                {
                    return await _students.Find<Student>(student => student.Id == objectId).FirstOrDefaultAsync();
                }
                return null;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: El formato del ID no es válido: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteStudentByDocument(string document)
        {
            var result = await _students.DeleteOneAsync(student => student.Document == document);
            return result.DeletedCount > 0;
        }
    }
}
