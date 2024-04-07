using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class ClassroomStudentService : IClassroomStudentService
{
    private readonly DapperContext _context;
    public ClassroomStudentService(DapperContext context)
    {
        _context = context;
    }
    public async Task<string> AddClassroomStudent(ClassroomStudent classroom)
    {
        var sql = "insert into ClassroomStudent(StudentId) values(@StudentId)";
        await _context.Connection().ExecuteAsync(sql, classroom);
        return "ClassroomStudent Added successfuly";
    }

    public async Task<string> DeleteClassroomStudent(int id)
    {
        var sql = "delete from ClassroomStudent where Id = @id";
        await _context.Connection().ExecuteAsync(sql, new { Id = id });
        return "ClassroomStudent deleted Successfuly";
    }

    public async Task<List<ClassroomStudent>> GetClassroomStudent()
    {
        var sql = "select * from ClassroomStudent";
        var result = await _context.Connection().QueryAsync<ClassroomStudent>(sql);
        return result.AsList();
    }

    public async Task<string> UpdateClassroomStudent(ClassroomStudent classroom)
    {
        var sql = "update ClassroomStudent set StudentId = @StudentId where Id = @Id";
        await _context.Connection().ExecuteAsync(sql, classroom);
        return "ClassroomStudent updated successfuly";
    }
   

}
