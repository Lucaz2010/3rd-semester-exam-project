
using Infrastructure.Data;
using Infrastructure.Entities;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;

namespace Api;

public class UserQueries(AppDataConnection db) : ControllerBase
{
    [HttpGet(nameof(GetAllUsers))]

    public List<User> GetAllUsers()
    {
        return db.Users().ToList();
    }

    [HttpPost(nameof(PostUser))]

    public void PostUser(User user)
    {
        user.Id = Guid.NewGuid().ToString();
        user.PasswordHash = "";
        db.Insert(user);
    }

    [HttpDelete(nameof(DeleteUser))]

    public void DeleteUser(string userId)
    {
        var user = db.Users().FirstOrDefault(u => u.Id == userId);
        if (user != null)
            db.Delete(user);
    }

    [HttpPut(nameof(EditUser))]

    public void EditUser(string userId, string newUsername, string newPassword)

    {
        var user = db.Users().FirstOrDefault(u => u.Id == userId);
        user.Name = newUsername;
        user.PasswordHash = "";
        db.Update(user);
    }

    [HttpPost(nameof(CreateHolidayRequest))]
    public void CreateHolidayRequest(HolidayRequest holidayRequest)
    {
        db.Insert(holidayRequest);
    }
    
    
    
    [HttpGet(nameof(GetHolidayRequests))]
    public List<HolidayRequest> GetHolidayRequests()
    {
        return db.HolidayRequests().LoadWith(h => h.User).ToList();
    }
}