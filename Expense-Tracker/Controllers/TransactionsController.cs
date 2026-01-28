using Expense_Tracker.Data;
using Expense_Tracker.Dtos.Transactions;
using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController(ExpenseTrackerDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TransactionDto>>> GetTransactions()
    {
        List<TransactionDto> transactions = await context.Transactions
            .Select(transaction => new TransactionDto(
                transaction.Id,
                transaction.Date,
                transaction.Amount,
                transaction.Description,
                transaction.AccountId
            ))
            .ToListAsync();
        return Ok(transactions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TransactionDto>> GetTransactionById(int id)
    {
        TransactionDto? transaction = await context.Transactions
            .Where(transaction => transaction.Id == id)
            .Select(transaction => new TransactionDto(
                transaction.Id,
                transaction.Date,
                transaction.Amount,
                transaction.Description,
                transaction.AccountId
            ))
            .FirstOrDefaultAsync();

        if (transaction == null)
            return NotFound();
        return Ok(transaction);
    }

    [HttpPost]
    public async Task<ActionResult<Transaction>> CreateTransaction(CreateTransactionDto createTransactionDto)
    {
        var transaction = new Transaction
        {
            Amount = createTransactionDto.Amount,
            Description = createTransactionDto.Description,
            AccountId = createTransactionDto.AccountId
        };

        await context.Transactions.AddAsync(transaction);
        await context.SaveChangesAsync();
        
        return CreatedAtAction("GetTransactionById", new { id = transaction.Id }, transaction);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TransactionDto>> UpdateTransaction(int id, UpdateTransactionDto updateTransactionDto)
    {
        Transaction? transaction = await context.Transactions.FindAsync(id);

        if (transaction == null)
            return NotFound();

        if (updateTransactionDto.Amount != null)
            transaction.Amount = updateTransactionDto.Amount.Value;

        await context.SaveChangesAsync();

        return Ok(new TransactionDto(
            transaction.Id,
            transaction.Date,
            transaction.Amount,
            transaction.Description,
            transaction.AccountId
        ));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        Transaction? transaction = await context.Transactions.FindAsync(id);

        if (transaction == null)
            return NotFound();

        context.Transactions.Remove(transaction);
        await context.SaveChangesAsync();
        
        return NoContent();
    }
}