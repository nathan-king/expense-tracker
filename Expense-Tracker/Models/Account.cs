namespace Expense_Tracker.Models;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; }
    public AccountType AccountType { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
}