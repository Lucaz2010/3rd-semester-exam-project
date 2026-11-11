namespace Infrastructure.Data;

using LinqToDB;
using LinqToDB.Data;
using Infrastructure.Entities;

public class AppDataConnection(DataOptions options) : DataConnection(options)
{
    public ITable<User> Users() => this.GetTable<User>();
    public ITable<Admin> Admins() => this.GetTable<Admin>();
    public ITable<HolidayRequest> HolidayRequests() => this.GetTable<HolidayRequest>();

}