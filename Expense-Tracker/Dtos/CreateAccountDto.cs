using Expense_Tracker.Models;

namespace Expense_Tracker.Dtos;

public record CreateAccountDto(string Name, AccountType AccountType, int UserId);