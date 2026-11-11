namespace Infrastructure.Entities;

using LinqToDB.Mapping;

[Table("HolidayRequests")]
public class HolidayRequest
{
    [PrimaryKey]
    [Column(Name = "Id"), NotNull]

    public String Id { get; set; }

    [Column]
    public string UserId { get; set; } = string.Empty;

    [Column]
    public DateTime StartDate { get; set; }

    [Column]
    public DateTime EndDate { get; set; }

    [Column]
    public string HolidayAccount { get; set; } = string.Empty;

    [Column]
    public int RequestedDays { get; set; }

    [Column]
    public decimal RequestedHours { get; set; }

    [Column]
    public string Status { get; set; } = "Pending";

    [Column]
    public DateTime CreatedAtUtc { get; set; }
    
    [Association(ThisKey = nameof(UserId), OtherKey = nameof(Entities.User.Id), CanBeNull = false)]
    public User User { get; set; } = null!;
}