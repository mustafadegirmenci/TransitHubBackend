using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Authentication;

public class UserLoginModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}