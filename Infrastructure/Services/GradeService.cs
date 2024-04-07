using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class GradeService : IGradeService
{
    private readonly DapperContext _context;
    public GradeService(DapperContext context)
    {
        _context = context;
    }
    public async Task<string> AddGrade(Grade grade)
    {
        var sql = "insert into Grade(Name) values(@Name)";
        await _context.Connection().ExecuteAsync(sql,grade);
        return "Grade Added successfuly";
    }
    public async Task<string> DeleteGrade(int id)
    {
        var sql = @"delete from Grade where Id = @id";
        await _context.Connection().ExecuteAsync(sql,new {Id = id});
        return "Grade deleted Successfuly";
    }
    public async Task<List<Grade>> GetGrade()
    {
        var sql = "select * from Grade";
        var result = await _context.Connection().QueryAsync<Grade>(sql);
        return result.AsList();
    }

    public async Task<string> UpdateGrade(Grade grade)
    {
        var sql = "update Grade set Name = @Name where Id = @id";
        await _context.Connection().ExecuteAsync(sql,grade);
        return "Grade Updated Successfuly";
    }
}
