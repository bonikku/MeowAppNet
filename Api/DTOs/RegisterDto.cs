using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
  public class RegisterDto
  {
    [Required]
    [MinLength(5)]
    [MaxLength(15)]
    public string UserName { get; set; }
    [Required]
    [MinLength(5)]
    [MaxLength(15)]
    public string Password { get; set; }
  }
}