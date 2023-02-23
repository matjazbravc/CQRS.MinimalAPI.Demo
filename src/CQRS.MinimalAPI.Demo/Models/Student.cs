using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS.MinimalAPI.Demo.Models;

public class Student
{
    public Student(string name, string? address, string? email, DateTime? dateOfBirth, bool? active = true)
    {
        Name = name;
        Address = address;
        Email = email;
        DateOfBirth = dateOfBirth;
        Active = active;
    }

    [Key]
    [Column(Order=1)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, MinLength(2)]
    [Column(Order=2)]
    [StringLength(100)]
    public string Name { get; set; }

    [Column(Order=3)]
    public string? Address { get; set; }
    
    [Required, EmailAddress]
    [Column(Order=4)]
    public string? Email { get; set; }

    [Column(Order=5)]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? DateOfBirth { get; set; }

    [Column(Order=6)]
    public bool? Active { get; set; }
}