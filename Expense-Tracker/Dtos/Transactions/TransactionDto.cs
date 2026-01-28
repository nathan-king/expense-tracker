namespace Expense_Tracker.Dtos.Transactions;

public record TransactionDto(
    int Id,
    DateTime Date,
    decimal Amount,
    string Description,
    int AccountId
);