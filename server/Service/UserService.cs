namespace Service;

using LinqToDB;
using Infrastructure.Data;
using Infrastructure.Entities;
using Service.DTOs;
using LinqToDB.Async;

public class UserService(AppDataConnection db)
{
    private readonly AppDataConnection _db = db;
    
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _db.Products.AsAsyncEnumerable().ToListAsync();
    }
}