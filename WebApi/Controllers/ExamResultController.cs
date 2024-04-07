using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Controller]
[Route("[controller]")]
public class ExamResultController : ControllerBase
{
     private readonly IExamResultService _service;
    public ExamResultController(IExamResultService service)
    {
        _service = service;
    }
      [HttpGet("Get-ExamResult")]
    public async Task<List<ExamResult>> GetExam()
    {
        return await _service.GetExamsResult();
    }
    [HttpPost("Add-ExamResult")]
    public async Task<string> AddExam(ExamResult exam)
    {
        return await _service.AddExamResult(exam);
    }
    [HttpDelete("Delete-ExamResult")]
    public async Task<string> DeleteExamResult(int id)
    {
        return await _service.DeleteExamResult(id);
    }
    [HttpPut("Update-ExamResult")]
    public async Task<string> UpdateExam(ExamResult exam)
    {
        return await _service.UpdateExamResult(exam);
    }
}
