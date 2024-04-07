namespace Domain.Models;

public class Attendance
{
    public int Id { get; set; }
    public DateTime ADate { get; set; }
    public int StudentId { get; set; }
    public bool Status { get; set; }
    public string? Remark { get; set; }
}
