using schoolsapi.models;

namespace SchoolsApi.Models
{
    public class Teacher : schoolgeriachy
    {
        public string Subject { get; set; } = string.Empty;  //materia O asignatura
        public int YearsOfExperience { get; set; } 
    }
}
