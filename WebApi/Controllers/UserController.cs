using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly RosaFiestaContext _context;  
    public UserController(RosaFiestaContext context)
    {
        _context = context;
    }

    [HttpGet("usuarios")]
    public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpPost("crearUsuario")]
    public async Task<ActionResult<UserModel>> CreateUser(UserModel user)
    {
        user.ID = Guid.NewGuid();
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    }


}
