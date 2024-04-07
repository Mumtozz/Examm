using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IStudentService
{
     Task<string> UpdateStudent(Student student);
     Task<string> DeleteStudent(int id);
     Task<string> AddStudent(Student student);
     Task<List<Student>> GetStudent();
     Task<List<AttendancyStudent>> GetAttendancyStudents();
     Task<List<ExamResultOfStudent>> GetExamResultOfStudents();
     Task<List<ExamResultStudentExam>> GetExamResultStudentExams();
     


}
