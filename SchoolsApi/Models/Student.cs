using MongoDB.Bson.Serialization.Attributes;
using schoolsapi.models;

namespace LeavesCinemaApi.Contracts.Models
{
    public class Student : schoolgeriachy
    {
        public DateTime DateOfEnrollment { get; set; } // Fecha de inscripción
        public double GPA { get; set; } // Promedio de calificaciones
        public string Degree { get; set; } = string.Empty; // Titulo o grado que esta cursando


    }
}
