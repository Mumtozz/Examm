using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ClassroomStudentController
{
    private readonly IClassroomStudentService _service;
    public ClassroomStudentController(IClassroomStudentService service)
    {
        _service = service;
    }
       [HttpGet("Get-ClassroomStudent")]
    public async Task<List<ClassroomStudent>> GetClassroom()
    {
        return await _service.GetClassroomStudent();
    }
    [HttpPost("Add-ClassroomStudent")]
    public async Task<string> AddClassroom(ClassroomStudent classroom)
    {
        return await _service.AddClassroomStudent(classroom);
    }
    [HttpDelete("Delete-ClassroomStudent")]
    public async Task<string> DeleteClassroom(int id)
    {
        return await _service.DeleteClassroomStudent(id);
    }
    [HttpPut("Update-ClassroomStudent")]
    public async Task<string> UpdateClassroom(ClassroomStudent classroom)
    {
        return await _service.UpdateClassroomStudent(classroom);
    }
}
