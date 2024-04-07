using System.Net;
using System.Collections.Generic;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Controller]
[Route("[controller]")]
public class ParentController : ControllerBase
{
    private readonly IParentService _parent;
    public ParentController(IParentService parentService)
    {
        _parent = parentService;
    }
    [HttpGet("GetParent")]
    public async Task<List<Parent>> GetParents()
    {
        return await _parent.GetParents();
    }
    [HttpPost("Add-Parent")]
    public async Task<string> AddParent(Parent parent)
    {
        return await _parent.AddParent(parent);
    }
    [HttpDelete("Delete-Parent")]
    public async Task<string> DeleteParent(int id)
    {
      return  await _parent.DeleteParent(id);
    }
    [HttpPut("Update-Parent")]
    public async Task<string> UpdateParent(Parent parent)
    {
        return await _parent.UpdateParent(parent);
    }
    [HttpGet("GetParentChildrens")]
    public async Task<List<ParentChildren>> GetParentChildrens()
    {
        return await _parent.GetParentChildrens();
    }
}
