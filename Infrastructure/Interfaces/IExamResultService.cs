using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IExamResultService
{
    Task<string> UpdateExamResult(ExamResult exam);
    Task<string> AddExamResult(ExamResult exam);
    Task<List<ExamResult>> GetExamsResult();
    Task<string> DeleteExamResult(int id);
}
