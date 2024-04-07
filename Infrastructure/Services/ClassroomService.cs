using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class ClassroomService : IClassromService
{
    private readonly DapperContext _context;
    public ClassroomService(DapperContext context)
    {
        _context = context;
    }
       public async Task<List<Classroom>> GetClassroom()
    {
        var sql = "select * from Classroom";
        var result = await _context.Connection().QueryAsync<Classroom>(sql);
        return result.AsList();
    }
     public async Task<string> DeleteClassroom(int id)
    {
        var sql = @"delete from Classroom where Id = @id";
        await _context.Connection().ExecuteAsync(sql,new {Id = id});
        return "Classroom deleted Successfuly";
    }
       public async Task<string> AddClassroom(Classroom classroom)
    {
        var sql = "insert into Classroom(Years,GradeId,Section,Status,Remarks,TeacherId) values(@Years,@GradeId,@Section,@Status,@Remarks,@TeacherId)";
        await _context.Connection().ExecuteAsync(sql, classroom);
        return "Classroom Added successfuly";
    }
      public async Task<string> UpdateClassroom(Classroom classroom)
    {
        var sql = @"update Classroom set Years = @Years,GradeId = @GradeId,Section = @Section,Status = @Status,Remarks = @Remarks,TeacherId = @TeacherId where Id = @id";
        await _context.Connection().ExecuteAsync(sql,classroom);
        return "Classroom Updated Successfuly";
    }
     public async Task<List<ClassroomGrade>> GetClassroomGrades()
    {
        var sql = @"select g.Name,c.years,c.Remarks from Grade as g
                    join Classroom as c on g.Id = c.GradeId";
        var result = await _context.Connection().QueryAsync<ClassroomGrade>(sql);
        return result.AsList();
    }
}
