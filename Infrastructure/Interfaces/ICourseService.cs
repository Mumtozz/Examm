using System.Threading.Tasks;
using Domain.Models;
namespace Infrastructure.Interfaces;

public interface ICourseService
{
    Task<string> UpdateCourse(Course course);
    Task<string> AddCourse(Course parent);
    Task<List<Course>> GetCourses();
    Task<string> DeleteCourse(int id);

}
