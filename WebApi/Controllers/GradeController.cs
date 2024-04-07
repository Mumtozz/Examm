using System.Net;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Controller]
[Route("[controller]")]
public class GradeController : ControllerBase
{
    private readonly IGradeService _gradeService;
    public GradeController(IGradeService gradeService)
    {
        _gradeService  = gradeService;
    }
    [HttpGet("Get-Grade")]
    public async Task<List<Grade>> GetGrade()
    {
        return await _gradeService.GetGrade();
    }
    [HttpPost("Add-Grade")]
    public async Task<string> AddGrade(Grade grade)
    {
        return await _gradeService.AddGrade(grade);
    }
    [HttpDelete("Delete-Grade")]
    public async Task<string> DeleteGrade(int id)
    {
        return await _gradeService.DeleteGrade(id);
    }
    [HttpPut("Update-Grade")]
    public async Task<string> UpdateGrade(Grade grade)
    {
        return await _gradeService.UpdateGrade(grade);
    }
}
