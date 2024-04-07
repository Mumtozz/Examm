namespace Domain.Models;

public class Classroom
{
    public int Id { get; set; }
    public int Years { get; set; }
    public int GradeId { get; set; }
    public string Section { get; set; }
    public bool Status { get; set; }
    public string Remarks { get; set; }
    public int TeacherId { get; set; }

}
