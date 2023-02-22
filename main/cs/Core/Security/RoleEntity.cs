using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Core.Security;

public class RoleEntity: IdentityRole
{
    public RoleEntity(string name, string normalizedName, string description)
    {
        Name = name;
        NormalizedName = normalizedName;
        Description = description;
        this.CreatedAt = DateTime.Now;
    }

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}