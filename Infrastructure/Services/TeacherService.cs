using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class TeacherService : ITeacherService
{
    private readonly DapperContext _context;
    public TeacherService(DapperContext context)
    {
        _context = context;
    }
    public async Task<List<Teacher>> GetTeachers()
    {
        var sql = "select * from Teacher";
        var result = await _context.Connection().QueryAsync<Teacher>(sql);
        return result.AsList();
    }

    public async Task<string> AddTeacher(Teacher teacher)
    {
        var sql = @"insert into Teacher(Email,Password,FullName,Dob,PhoneNumber,Status,LastLoginDate)
                    values(@Email,@Password,@FullName,@Dob,@PhoneNumber,@Status,@LastLoginDate)";
        await _context.Connection().ExecuteAsync(sql, teacher);
        return "Teacher Added successfuly";
    }
    public async Task<string> DeleteTeacher(int id)
    {
        var sql = "delete from Teacher where Id = @id";
        await _context.Connection().ExecuteAsync(sql, new { Id = id });
        return "Teacher Deleted Successfuly";
    }
    public async Task<string> UpdateTeacher(Teacher teacher)
    {
        var sql = @"update Teacher set Email = @Email,Password = @Password,FullName = @FullName,
                            Dob = @Dob,PhoneNumber = @PhoneNumber,Status = @Status,LastLoginDate = @LastLoginDate";
        await _context.Connection().ExecuteAsync(sql, teacher);
        return "Teacher Updated Successfuly";

    }
}
