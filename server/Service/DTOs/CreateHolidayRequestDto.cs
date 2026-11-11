namespace Service.DTOs;

using System;
using System.ComponentModel.DataAnnotations;

public class CreateHolidayRequestDto
{
    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    [RegularExpression("^(Weeks1To5|Week6)$",
        ErrorMessage = "Invalid holiday account.")]
    public string HolidayAccount { get; set; } = string.Empty;
}