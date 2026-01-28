using Expense_Tracker.Models;

namespace Expense_Tracker.Dtos.Accounts;

public class UpdateAccountDto
{
    public string? Name { get; set; }
    public AccountType? AccountType { get; set; }
}