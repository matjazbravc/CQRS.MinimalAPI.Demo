using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS.MinimalAPI.Demo.Models;

public record Student(string Name, string? Address, string? Email, DateTime? DateOfBirth, bool? Active = true)
{
  [Key]
  [Column(Order = 1)]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  [Required, MinLength(2)]
  [Column(Order = 2)]
  [StringLength(100)]
  public string Name { get; set; } = Name;

  [Column(Order = 3)]
  public string? Address { get; set; } = Address;

  [Required, EmailAddress]
  [Column(Order = 4)]
  public string? Email { get; set; } = Email;

  [Column(Order = 5)]
  [DataType(DataType.Date)]
  [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
  public DateTime? DateOfBirth { get; set; } = DateOfBirth;

  [Column(Order = 6)]
  public bool? Active { get; set; } = Active;
}