using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class UserModel
{
     public Guid ID { get; set; }

     [MinLength(3), MaxLength(30)]
     public string? FirstName { get; set; }

     [MinLength(3), MaxLength(30)]
     public string? LastName { get; set; }

     [Range(5, 120)]
     public int Age { get; set; }

     [MinLength(3), MaxLength(30)]
     public string? CivilStatus { get; set; }



}
