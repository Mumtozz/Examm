namespace Domain.Models;

public class ExamResultOfStudent
{
    public string FullName { get; set; }
    public DateTime Dob { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Marks { get; set; }
    public int CourseId { get; set; }
}
