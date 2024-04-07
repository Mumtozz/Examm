using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class ExamService : IExamService
{
    private readonly DapperContext _context;
    public ExamService(DapperContext context)
    {
        _context = context;
    }

    public async Task<string> AddExam(Exam exam)
    {
        var sql = "insert into Exam(Name,StartDate) values(@Name,@StartDate)";
        await _context.Connection().ExecuteAsync(sql, exam);
        return "Exam Added successfuly";
    }

    public async Task<string> DeleteExam(int id)
    {
        var sql = "delete from Exam where Id = @id";
        await _context.Connection().ExecuteAsync(sql,new {Id = id});
        return "Exam Deleted Successfuly";
    }

    public async Task<List<Exam>> GetExams()
    {
        var sql = "select * from Exam";
        var result = await _context.Connection().QueryAsync<Exam>(sql);
        return result.AsList();
    }

    public async Task<string> UpdateExam(Exam exam)
    {
        var sql = "update Exam set Name = @Name,StartDate = @StartDate where Id = @id";
       await _context.Connection().ExecuteAsync(sql,exam);
        return "ExamUpdated Successfuly";
    }

}
