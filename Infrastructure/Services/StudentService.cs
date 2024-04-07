using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class StudentService : IStudentService
{
    private readonly DapperContext _context;
    public StudentService(DapperContext context)
    {
        _context = context;
    }
    public async Task<List<Student>> GetStudent()
    {
        var sql = "select * from Student";
        var result = await _context.Connection().QueryAsync<Student>(sql);
        return result.AsList();
    }

    public async Task<string> AddStudent(Student student)
    {
        var sql = @"insert into Student(Email,Password,FullName,Dob,PhoneNumber,ParentId,DateOfJoin,Status,LastLogin)
                    values(@Email,@Password,@FullName,@Dob,@PhoneNumber,@ParentId,@DateOfJoin,@Status,@LastLogin)";
        await _context.Connection().ExecuteAsync(sql, student);
        return "Student Added successfuly";
    }
    public async Task<string> DeleteStudent(int id)
    {
        var sql = "delete from Student where Id = @id";
        await _context.Connection().ExecuteAsync(sql, new { Id = id });
        return "Student Deleted Successfuly";
    }
    public async Task<string> UpdateStudent(Student student)
    {
        var sql = @"update Student set Email = @Email,Password = @Password,FullName = @FullName,
                            Dob = @Dob,PhoneNumber = @PhoneNumber,ParentId = @ParentId,DateOfJoin = @DateOfJoin,Status = @Status,LastLogin = @LastLogin";
        await _context.Connection().ExecuteAsync(sql, student);
        return "Student Updated Successfuly";
    }
    public async Task<List<AttendancyStudent>> GetAttendancyStudents()
    {
        var sql = @"select s.FullName,s.Dob,s.PhoneNumber,a.Status,a.Remark from Student as s
                    join Attendance as a on s.Id =  a.StudentId";
        var result = await _context.Connection().QueryAsync<AttendancyStudent>(sql);
        return result.AsList();
    }
    public async Task<List<ExamResultOfStudent>> GetExamResultOfStudents()
    {
        var sql = @"select s.FullName,s.Dob,s.PhoneNumber,e.Marks,e.CourseId from Student as s
                    join ExamResult as e on s.Id = e.StudentId";
        var result = await _context.Connection().QueryAsync<ExamResultOfStudent>(sql);
        return result.AsList();
    }
    public async Task<List<ExamResultStudentExam>> GetExamResultStudentExams()
    {
        var sql = @"select  s.FullName,s.Dob,s.PhoneNumber,er.Marks,e.Name from Exam as e
                    join ExamResult as er on e.Id = er.ExamId
                    join Student as s on er.StudentId = s.Id";
        var result = await _context.Connection().QueryAsync<ExamResultStudentExam>(sql);
        return result.AsList();
    }
}
