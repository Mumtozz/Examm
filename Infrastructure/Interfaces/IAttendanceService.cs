using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IAttendanceService
{
    Task<string> UpdateAttendance(Attendance attendance);
    Task<string> DeleteAttendance(int id);
    Task<string> AddAttendance(Attendance attendance);
    Task<List<Attendance>> GetAttendance();
}
