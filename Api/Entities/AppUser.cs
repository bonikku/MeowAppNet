using System.ComponentModel.DataAnnotations;
using Api.Extensions;

namespace Api.Entities;
public class AppUser
{
  public int Id { get; set; }
  public string UserName { get; set; }
  public byte[] PasswordHash { get; set; }
  public byte[] PasswordSalt { get; set; }
  public DateOnly BirthDay { get; set; }
  public string Nickname { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime LastActive { get; set; } = DateTime.Now;
  public string Gender { get; set; }
  public string Introduction { get; set; }
  public string MeowingFor { get; set; }
  public string City { get; set; }
  public string Country { get; set; }
  public List<Photo> Photos { get; set; } = new(); //new List<Photo>();

  // public int GetAge()
  // {
  //   return BirthDay.CalculateAge();
  // }
}