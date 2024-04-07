using System.Net;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Controller]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _student;
    public StudentController(IStudentService student)
    {
        _student = student;
    }
    [HttpGet("Get-Students")]
    public async Task<List<Student>> GetStudents()
    {
        return await _student.GetStudent();
    }
    [HttpPost("Add-Student")]
    public async Task<string> AddStudent(Student student)
    {
        return await _student.AddStudent(student);
    }
    [HttpDelete("Delete-Student")]
    public async Task<string> DeleteStudent(int id)
    {
        return await _student.DeleteStudent(id);
    }
    [HttpPut("Update-Student")]
    public async Task<string> UpdateStudent(Student student)
    {
        return await _student.UpdateStudent(student);
    }
    [HttpGet("GetAttendancyStudents")]
    public async Task<List<AttendancyStudent>> GetAttendancyStudents()
    {
        return await _student.GetAttendancyStudents();
    }
    [HttpGet("GetExamResultOfStudents")]
    public async Task<List<ExamResultOfStudent>> GetExamResultOfStudents()
    {
        return await _student.GetExamResultOfStudents();
    }
    [HttpGet("GetExamResultStudentExams")]
    public async Task<List<ExamResultStudentExam>> GetExamResultStudentExams()
    {
        return await _student.GetExamResultStudentExams();
    }
}
