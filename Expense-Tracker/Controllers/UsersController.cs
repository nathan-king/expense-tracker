using Expense_Tracker.Data;
using Expense_Tracker.Dtos;
using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(ExpenseTrackerDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetUsers()
    {
        List<UserDto> users = await context.Users
            .Select(user => new UserDto(
                user.Id,
                user.Name,
                user.Email
            ))
            .ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserById(int id)
    {
        UserDto? user = await context.Users
            .Where(user => user.Id == id)
            .Select(user => new UserDto(
                user.Id,
                user.Name,
                user.Email
            ))
            .FirstOrDefaultAsync();
        
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(CreateUserDto createUserDto)
    {
        var user = new User
        {
            Name = createUserDto.Name,
            Email = createUserDto.Email
        };
        
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }
}