using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models;

public class User
{
    public int Id { get; set; }

    [StringLength(20)] public required string Name { get; set; } = null!;
    
    [EmailAddress]
    [StringLength(255)]
    public required string Email { get; set; }
    
    public List<Account> Accounts { get; set; } = new List<Account>();
}