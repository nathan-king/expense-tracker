namespace Expense_Tracker.Dtos;

public class CreateUserDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
}