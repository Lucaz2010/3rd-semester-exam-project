namespace Service;

using LinqToDB;
using Infrastructure.Data;
using Infrastructure.Entities;
using Service.DTOs;
using LinqToDB.Async;

//test commit
public class UserService (AppDbConnection db)
{
    public List<User> GetUsers()
    {
        return db.Users.ToList();
    }
}