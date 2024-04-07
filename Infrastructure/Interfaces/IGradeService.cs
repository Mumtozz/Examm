using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IGradeService
{
    
    Task<string> UpdateGrade(Grade grade);
    Task<string> AddGrade(Grade grade);
    Task<List<Grade>> GetGrade();
    Task<string> DeleteGrade(int id);
}
