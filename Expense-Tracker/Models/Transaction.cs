using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Models;

public class Transaction
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    
    [Precision(18, 2)]
    public required decimal Amount { get; set; }
    
    [StringLength(500)]
    public required string Description { get; set; } = null!;
    
    public Account Account { get; set; } = null!;
    public int AccountId { get; set; }
}