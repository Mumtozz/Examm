using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Controller]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _service;
    public TeacherController(ITeacherService service)
    {
        _service = service;
    }
    [HttpGet("Get-Teachers")]
    public async Task<List<Teacher>> GetTeachers()
    {
        return await _service.GetTeachers();
    }
    [HttpPost("Add-Teacher")]
    public async Task<string> AddTeacher(Teacher teacher)
    {
        return await _service.AddTeacher(teacher);
    }
    [HttpDelete("Delete-Teacher")]
    public async Task<string> DeleteTeacher(int id)
    {
        return await _service.DeleteTeacher(id);
    }
    [HttpPut("Update-Teacher")]
    public async Task<string> UpdateTeacher(Teacher teacher)
    {
        return await _service.UpdateTeacher(teacher);
    }
}
