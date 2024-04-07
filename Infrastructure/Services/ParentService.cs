using System.Collections.Generic;
using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class ParentService : IParentService
{
    private readonly DapperContext _context;
    public ParentService(DapperContext context)
    {
        _context = context;
    }
    public async Task<List<Parent>> GetParents()
    {
        var sql = "select * from Parent";
        var result = await _context.Connection().QueryAsync<Parent>(sql);
        return result.AsList();
    }
    public async Task<string> AddParent(Parent parent)
    {
        var sql = @"insert into Parent(Email,Password,FullName,Dob,PhoneNumber,Status,LastLoginDate)
                    values(@Email,@Password,@FullName,@Dob,@PhoneNumber,@Status,@LastLoginDate)";
        await _context.Connection().ExecuteAsync(sql, parent);
        return "Parent Added successfuly";
    }
    public async Task<string> DeleteParent(int id)
    {
        var sql = "delete from Parent where Id = @id";
        await _context.Connection().ExecuteAsync(sql, new { Id = id });
        return "Parent deleted successfuly";
    }
    public async Task<string> UpdateParent(Parent parent)
    {
        var sql = "update Parent set Email = @Email,Password = @Password,FullName = @FullName,Dob = @Dob,PhoneNumber = @PhoneNumber,Status = @Status,LastLoginDate = @LastLoginDate";
        await _context.Connection().ExecuteAsync(sql, parent);
        return "Parent Updated Successfuly";
    }
    public async Task<List<ParentChildren>> GetParentChildrens()
    {
        var sql = @"select s.FullName as StudentFullName,s.Dob,s.PhoneNumber,p.FullName as ParentName from Parent as p
                    join Student as s on p.Id = s.ParentId";
                    var result = await _context.Connection().QueryAsync<ParentChildren>(sql);
                    return result.AsList();
    }
}



