using Expense_Tracker.Data;
using Expense_Tracker.Dtos;
using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController(ExpenseTrackerDbContext context) : ControllerBase // C# 12 primary constructor
{
    [HttpGet]
    public async Task<List<Account>> GetAccounts()
    {
        return await context.Accounts
            .Include(a => a.User)
            .ToListAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Account>> GetAccountById(int id)
    {
        Account? account = await context.Accounts.FindAsync(id);
        if (account == null)
        {
            return NotFound();
        }
        return Ok(account);
    }

    [HttpPost]
    public async Task<ActionResult<Account>> CreateAccount(CreateAccountDto createAccountDto)
    {
        var account = new Account
        {
            Name = createAccountDto.Name,
            AccountType = createAccountDto.AccountType,
            UserId = createAccountDto.UserId
        };

        await context.Accounts.AddAsync(account);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetAccountById), new { id = account.Id }, account);
    }
}