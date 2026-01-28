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
    public async Task<ActionResult<List<AccountDto>>> GetAccounts()
    {
        List<AccountDto> accounts = await context.Accounts
            .Select(account => new AccountDto(
                account.Id,
                account.Name,
                account.AccountType,
                account.UserId
            ))
            .ToListAsync();
        return Ok(accounts);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<AccountDto>> GetAccountById(int id)
    {
        AccountDto? account = await context.Accounts
            .Where(account => account.Id == id)
            .Select(account => new AccountDto(
                account.Id,
                account.Name,
                account.AccountType,
                account.UserId
            ))
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

    [HttpPut("{id}")]   
    public async Task<ActionResult<AccountDto>> UpdateAccount(int id, UpdateAccountDto updateAccountDto)
    {
        Account? account = await context.Accounts.FindAsync(id);

        if (account == null)
            return NotFound();

        if (updateAccountDto.Name != null)
            account.Name = updateAccountDto.Name;

        if (updateAccountDto.AccountType != null)
            account.AccountType = updateAccountDto.AccountType.Value;
        
        await context.SaveChangesAsync();

        return Ok(new AccountDto(
            account.Id,
            account.Name,
            account.AccountType,
            account.UserId
        ));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount(int id)
    {
        Account? account = await context.Accounts.FindAsync(id);

        if (account == null)
            return NotFound();
        
        context.Accounts.Remove(account);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
}