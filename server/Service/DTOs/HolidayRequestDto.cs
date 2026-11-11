namespace Service.DTOs;

using System;

public class HolidayRequestDto
{
    public Guid Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string HolidayAccount { get; set; } = string.Empty;

    public int RequestedDays { get; set; }

    public decimal RequestedHours { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAtUtc { get; set; }
}