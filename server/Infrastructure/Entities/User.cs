namespace Infrastructure.Entities;

using LinqToDB.Mapping;

[Table(Name = "Users")]
public class User
{
    [PrimaryKey, Identity]
    public int Id { get; set; }
    
    [Column(Name = "Name"),  NotNull]
    public string Name { get; set; } = string.Empty;
    
    [Column(Name = "Email"), NotNull]
    public string Email { get; set; }
}