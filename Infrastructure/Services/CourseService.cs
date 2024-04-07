using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class CourseService : ICourseService
{
    private readonly DapperContext _context;
    public CourseService(DapperContext context)
    {
        _context = context;
    }
    public async Task<string> AddCourse(Course course)
    {
        var sql = "insert into Course (Name,Description,GradeId) values(@Name,@Description,@GradeId)";
        await _context.Connection().ExecuteAsync(sql,course);
        return "Course Added successuly";
    }


    public async Task<string> DeleteCourse(int id)
    {
        var sql = "delete from Course where Id = @id";
        await _context.Connection().ExecuteAsync(sql, new { Id = id });
        return "Course Deleted Successfuly";
    }

    public async Task<List<Course>> GetCourses()
    {
        var sql = "select * from Course";
        var result = await _context.Connection().QueryAsync<Course>(sql);
        return result.AsList();
    }

    public async Task<string> UpdateCourse(Course course)
    {
        var sql = @"update Course set Name = @Name,Description = @Description,GradeId = @GradeId where Id = @id";
        await _context.Connection().ExecuteAsync(sql,course);
        return "Course Updated Successfuly";
    }

}
