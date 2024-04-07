using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Controller]
[Route("[controller]")]
public class ExamController : ControllerBase
{
    private readonly IExamService _service;
    public ExamController(IExamService service)
    {
        _service = service;
    }
      [HttpGet("Get-Exam")]
    public async Task<List<Exam>> GetExam()
    {
        return await _service.GetExams();
    }
    [HttpPost("Add-Exam")]
    public async Task<string> AddExam(Exam exam)
    {
        return await _service.AddExam(exam);
    }
    [HttpDelete("Delete-Exam")]
    public async Task<string> DeleteExam(int id)
    {
        return await _service.DeleteExam(id);
    }
    [HttpPut("Update-Exam")]
    public async Task<string> UpdateExam(Exam exam)
    {
        return await _service.UpdateExam(exam);
    }
}
