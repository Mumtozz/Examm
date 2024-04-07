using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Controller]
[Route("[controller]")]
public class ClassroomController : ControllerBase
{
    private readonly IClassromService _service;
    public ClassroomController(IClassromService service)
    {
        _service = service;
    }
     [HttpGet("Get-Classroom")]
    public async Task<List<Classroom>> GetClassroom()
    {
        return await _service.GetClassroom();
    }
    [HttpPost("Add-Classroom")]
    public async Task<string> AddClassroom(Classroom classroom)
    {
        return await _service.AddClassroom(classroom);
    }
    [HttpDelete("Delete-Classroom")]
    public async Task<string> DeleteClassroom(int id)
    {
        return await _service.DeleteClassroom(id);
    }
    [HttpPut("Update-Classroom")]
    public async Task<string> UpdateClassroom(Classroom classroom)
    {
        return await _service.UpdateClassroom(classroom);
    }
    [HttpGet("GetClassroomGrades")]
    public async Task<List<ClassroomGrade>> GetClassroomGrades()
    {
        return await _service.GetClassroomGrades();
    }
}
