using Expense_Tracker.Models;

namespace Expense_Tracker.Dtos;

public record AccountDto(int Id, string Name, AccountType AccountType, int UserId);