using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class AttendanceService : IAttendanceService
{
    private readonly DapperContext _context;
    public AttendanceService(DapperContext context)
    {
        _context = context;
    }
    public async Task<List<Attendance>> GetAttendance()
    {
        var sql = "select * from Attendance";
        var result = await _context.Connection().QueryAsync<Attendance>(sql);
        return result.AsList();
    }
    public async Task<string> DeleteAttendance(int id)
    {
        var sql = @"delete from Attendance where Id = @id";
        await _context.Connection().ExecuteAsync(sql, new { Id = id });
        return "Attendance deleted Successfuly";
    }
    public async Task<string> AddAttendance(Attendance attendance)
    {
        var sql = "insert into Attendance(ADate,StudentId,Status,Remark) values(@ADate,@StudentId,@Status,@Remark)";
        await _context.Connection().ExecuteAsync(sql, attendance);
        return "Attendance Added successfuly";
    }
    public async Task<string> UpdateAttendance(Attendance attendance)
    {
        var sql = @"update Attendance set ADate = @ADate,StudentId = @StudentId,Status = @Status,Remark = @Remark where Id = @id";
        await _context.Connection().ExecuteAsync(sql, attendance);
        return "Attendance Updated Successfuly";
    }
}
