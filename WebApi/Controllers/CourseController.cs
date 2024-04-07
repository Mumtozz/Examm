using System.Net;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Controller]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }
    [HttpGet("Get-Course")]
    public async Task<List<Course>> GetCourses()
    {
        return await _courseService.GetCourses();
    }
    [HttpPost("Add-Course")]
    public async Task<string> AddCourse(Course course)
    {
        return await _courseService.AddCourse(course);
    }
    [HttpDelete("Delete-Course")]
    public async Task<string> DeleteCourse(int id)
    {
        return await _courseService.DeleteCourse(id);
    }
    [HttpPut("Update-Course")]
    public async Task<string> UpdateCourse(Course course)
    {
        return await _courseService.UpdateCourse(course);
    }

}
