using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IClassroomStudentService
{
    
    Task<string> UpdateClassroomStudent(ClassroomStudent classroom);
    Task<string> DeleteClassroomStudent(int id);
    Task<string> AddClassroomStudent(ClassroomStudent classroom);
    Task<List<ClassroomStudent>> GetClassroomStudent();
}
