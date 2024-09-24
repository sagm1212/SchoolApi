using LeavesCinemaApi.Core.Services.Interfaces;
using LeavesCinemaApi.Core.Services;
using LeavesCinemaApi.Infrastructure.Repositories.Interfaces;
using LeavesCinemaApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<ITeacherService, TeacherService>();
builder.Services.AddSingleton<ITeacherRepository, TeacherRepository>();


builder.Services.AddSingleton<IStudentService, StudentService>();
builder.Services.AddSingleton<IStudentRepository, StudentRepository>(); 



var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
