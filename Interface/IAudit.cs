
namespace Calculator
{
    interface IAudit
    {
        string СheckNumericCharacter(string input, string[] symbol);

        string CheckQuantity(string input, string[] symbol);

        string CorrectInput(string input, string[] symbol);
    }
}
