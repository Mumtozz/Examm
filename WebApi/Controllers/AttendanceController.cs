using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Controller]
[Route("[controller]")]
public class AttendanceController : ControllerBase
{
     private readonly IAttendanceService _service;
    public AttendanceController(IAttendanceService service)
    {
        _service = service;
    }
     [HttpGet("Get-Attendance")]
    public async Task<List<Attendance>> GetAttendance()
    {
        return await _service.GetAttendance();
    }
    [HttpPost("Add-Attendance")]
    public async Task<string> AddAttendance(Attendance attendance)
    {
        return await _service.AddAttendance(attendance);
    }
    [HttpDelete("Delete-Attendance")]
    public async Task<string> DeleteAttendance(int id)
    {
        return await _service.DeleteAttendance(id);
    }
    [HttpPut("Update-Attendance")]
    public async Task<string> UpdateAttendance(Attendance attendance)
    {
        return await _service.UpdateAttendance(attendance);
    }
}
