using System.ComponentModel.DataAnnotations;

namespace Service.DTOs;

public record CreateUserRequestDto{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
    [Required]
    public string Role { get; set; }
    
}