
namespace ConsoleApp
{
    interface IAudit
    {
        string СheckNumericCharacter(string input, string[] symbol);

        string CheckAvailability(string input);

        string CheckQuantity(string input, string[] symbol);
    }
}
