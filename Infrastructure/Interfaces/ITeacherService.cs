using Domain.Models;

namespace Infrastructure.Interfaces;

public interface ITeacherService
{
    
    Task<string> UpdateTeacher(Teacher teacher);
    Task<string> AddTeacher(Teacher teacher);
    Task<List<Teacher>> GetTeachers();
    Task<string> DeleteTeacher(int id);

}
