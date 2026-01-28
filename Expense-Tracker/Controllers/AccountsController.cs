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
    public async Task<ActionResult<AccountDto>> GetAccounts()
    {
        List<AccountDto> accounts = await context.Accounts
            .Select(account => new AccountDto
            {
                Id = account.Id,
                Name = account.Name,
                AccountType = account.AccountType,
                UserId = account.UserId
            })
            .ToListAsync();
        return Ok(accounts);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<AccountDto>> GetAccountById(int id)
    {
        AccountDto? account = await context.Accounts
            .Where(account => account.Id == id)
            .Select(account => new AccountDto
            {
                Id = account.Id,
                Name = account.Name,
                AccountType = account.AccountType,
                UserId = account.UserId
            })
            .FirstOrDefaultAsync();
        
        if (account == null)
            return NotFound();
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