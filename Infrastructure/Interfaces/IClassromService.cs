using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IClassromService
{
    Task<string> UpdateClassroom(Classroom classroom);
    Task<string> DeleteClassroom(int id);
    Task<string> AddClassroom(Classroom classroom);
    Task<List<Classroom>> GetClassroom();
    Task<List<ClassroomGrade>> GetClassroomGrades();

}
