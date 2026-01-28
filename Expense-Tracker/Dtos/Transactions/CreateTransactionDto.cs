using Expense_Tracker.Models;

namespace Expense_Tracker.Dtos.Transactions;

public record CreateTransactionDto(
    decimal Amount, 
    string Description, 
    int AccountId
);