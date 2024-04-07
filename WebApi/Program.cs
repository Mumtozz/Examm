using System.Collections.Immutable;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using Infrastructure.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<IParentService,ParentService>();
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<IGradeService,GradeService>();
builder.Services.AddScoped<ITeacherService,TeacherService>();
builder.Services.AddScoped<IClassromService,ClassroomService>();
builder.Services.AddScoped<IClassroomStudentService,ClassroomStudentService>();
builder.Services.AddScoped<IExamService,ExamService>();
builder.Services.AddScoped<IExamResultService,ExamResultService>();
builder.Services.AddScoped<IAttendanceService,AttendanceService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
