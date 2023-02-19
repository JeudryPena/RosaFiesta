using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models;

public class ProductModel
{
     public Guid ID { get; set; }

     [MinLength(3), MaxLength(30)]
     public string Name { get; set; }

     [MinLength(3), MaxLength(30)]
     public string Description { get; set; }

     [Range(1, 100000)]
     public int Price { get; set; }

     public bool IsAvailable { get; set; }
     
     public DateTime AddedAt { get; set; }
}
