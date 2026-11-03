using Dalilacademy.API.Middekware;
using Dalilacademy.Core.Service;
using Dalilacademy.infra.Data;
using Dalilacademy.infra.Repository;
using Dalilacademy.infra.Service;
using Dalilacademy_.Core.DTOs;
using Dalilacademy_.Core.Repository;
using Dalilacademy_.Core.Validdator;  
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddEndpointsApiExplorer(); // Important for minimal APIs + Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "Dalil Academy LMS API",
        Version = "v1",
        Description = "Learning Management System API built with ASP.NET Core 10"
    });
});

// Course
builder.Services.AddScoped<ICourserepository, CourseRepositore>();
builder.Services.AddScoped<ICourseService, CourseService>();

// Student
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

// Instructor
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<IInstructorService, InstructorService>();

// Enrollment
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// FluentValidation validators (one per entity: Course, Student, Instructor, Enrollment)
builder.Services.AddScoped<IValidator<CreateCourseDTo>, CreateCourseDTOValiddator>();
builder.Services.AddScoped<IValidator<UpdateCourseDto>, UpdateCourseDTOValiddator>();

builder.Services.AddScoped<IValidator<CreateStudentDto>, CreateStudentDTOValiddator>();
builder.Services.AddScoped<IValidator<UpdateStudentDto>, UpdateStudentDTOValiddator>();

builder.Services.AddScoped<IValidator<CreateInstructorDto>, CreateInstructorDTOValiddator>();
builder.Services.AddScoped<IValidator<UpdateInstructorDto>, UpdateInstructorDTOValiddator>();

builder.Services.AddScoped<IValidator<CreateEnrollmentDto>, CreateEnrollmentDTOValiddator>();
builder.Services.AddScoped<IValidator<UpdateEnrollmentDto>, UpdateEnrollmentDTOValiddator>();

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


var app = builder.Build();//line 
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Dalil Academy API v1");
        options.RoutePrefix = string.Empty; // Swagger at root
    });
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
