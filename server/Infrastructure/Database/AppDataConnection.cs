namespace Infrastructure.Data;

using LinqToDB;
using LinqToDB.Data;
using Infrastructure.Entities;

public class AppDbConnection : DataConnection
{
    public AppDbConnection(DataOptions<AppDbConnection> options) : base(options.Options)
    {
        
    }
  
    public ITable<User> Users => this.GetTable<User>();
}
