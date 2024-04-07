using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class ExamResultService : IExamResultService
{
    private readonly DapperContext _context;
    public ExamResultService(DapperContext context)
    {
        _context = context;
    }
    public async Task<string> AddExamResult(ExamResult exam)
    {
        var sql = "insert into ExamResult(ExamId,StudentId,CourseId,Marks) values(@ExamId,@StudentId,@CourseId,@Marks)";
        await _context.Connection().ExecuteAsync(sql, exam);
        return "ExamResult Added successfuly";
    }

    public async Task<string> DeleteExamResult(int id)
    {
        var sql = "delete from ExamResult where Id = @id";
        await _context.Connection().ExecuteAsync(sql,new {Id = id});
        return "ExamResult deleted Successfuly";
    }

    public async Task<List<ExamResult>> GetExamsResult()
    {
        var sql = "select * from ExamResult";
        var result = await _context.Connection().QueryAsync<ExamResult>(sql);
        return result.AsList();
    }

    public async Task<string> UpdateExamResult(ExamResult exam)
    {
        var sql = "update ExamResult set ExamId = @ExamId,StudentId = @StudentId,CourseId = @CourseId,Marks = @Marks";
        await _context.Connection().ExecuteAsync(sql,exam);
        return "ExamResult Updated Successfuly";
    }


}
