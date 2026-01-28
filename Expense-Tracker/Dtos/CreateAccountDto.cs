using Expense_Tracker.Models;

namespace Expense_Tracker.Dtos;

public class CreateAccountDto
{
    public required string Name { get; set; }
    public required AccountType AccountType { get; set; }
    public required int UserId { get; set; }
}