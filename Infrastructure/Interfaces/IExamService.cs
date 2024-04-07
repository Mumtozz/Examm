using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IExamService
{
    Task<string> UpdateExam(Exam exam);
    Task<string> AddExam(Exam exam);
    Task<List<Exam>> GetExams();
    Task<string> DeleteExam(int id);
}
