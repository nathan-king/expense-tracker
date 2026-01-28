namespace Expense_Tracker.Dtos.Transactions;

public class UpdateTransactionDto
{
    public decimal?  Amount { get; set; }
    public string?  Description { get; set; }
}