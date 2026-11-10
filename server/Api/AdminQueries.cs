
using Infrastructure.Data;
using Infrastructure.Entities;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;

namespace Api;

public class AdminQueries(AppDataConnection db) : ControllerBase
{
    [HttpGet(nameof(GetAllAdmins))]
    public List<Admin> GetAllAdmins()
    {
        return db.Admins().ToList();
    }

    [HttpPost(nameof(PostAdmin))]
    public void PostAdmin(Admin admin)
    {
        admin.Id = Guid.NewGuid().ToString();
        admin.PasswordHash = "";

        db.Insert(admin);
    }

    [HttpDelete(nameof(DeleteAdmin))]
    public void DeleteAdmin(string adminId)
    {
        var admin = db.Admins().FirstOrDefault(a => a.Id == adminId);
        if (admin != null)
            db.Delete(admin);
    }
    
    
    [HttpPut(nameof(EditAdmin))]

    public void EditAdmin(string adminId, string newUsername, string newPassword)
    
    {
        var admin = db.Admins().FirstOrDefault(a => a.Id == adminId);
        admin.Name = newUsername;
        admin.PasswordHash = "";
        db.Update(admin);
    }

}