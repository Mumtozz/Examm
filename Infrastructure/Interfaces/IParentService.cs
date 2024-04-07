using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IParentService
{
    Task<string> UpdateParent(Parent course);
    Task<string> AddParent(Parent course);
    Task<List<Parent>> GetParents();
    Task<string> DeleteParent(int id);
    Task<List<ParentChildren>> GetParentChildrens();
    
}


