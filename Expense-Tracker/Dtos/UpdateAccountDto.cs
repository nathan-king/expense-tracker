using Expense_Tracker.Models;

namespace Expense_Tracker.Dtos;

public class UpdateAccountDto
{
    public string? Name { get; set; }
    public AccountType? AccountType { get; set; }
}