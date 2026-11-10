namespace Infrastructure.Entities;

using LinqToDB.Mapping;

[Table(Name = "Admins")]
public class Admin
{
    [PrimaryKey]
    [Column(Name = "id"), NotNull]
    public string Id { get; set; }
    
    [Column(Name = "Name"),  NotNull]
    public string Name { get; set; } = string.Empty;
    
    [Column(Name = "Email"), NotNull]
    public string Email { get; set; }
    
    [Column(Name = "PasswordHash"), NotNull]
    public string PasswordHash { get; set; }
}