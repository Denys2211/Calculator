
namespace Calculator
{
    interface IAudit
    {
        string СheckNumericCharacter(string input, string[] symbol);

        string CheckQuantity(string input);

        string CorrectInput(string input);

        string CheckAvailability(string input);
    }
}
