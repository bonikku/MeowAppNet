using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
  public class RegisterDto
  {
    [Required]
    [MinLength(6)]
    [MaxLength(15)]
    public string UserName { get; set; }
    [Required]
    [MinLength(6)]
    [MaxLength(15)]
    public string Password { get; set; }
  }
}