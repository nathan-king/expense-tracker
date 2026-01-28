using Expense_Tracker.Models;

namespace Expense_Tracker.Dtos;

public class AccountDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public AccountType AccountType { get; set; }
    public int UserId { get; set; }
}