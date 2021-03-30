
namespace Calculator
{
    interface IAudit
    {
        void СheckNumericCharacter(string input, string[] symbol, out int countNumbers);

        void CheckQuantity(string input);

        void CorrectInput(string input, out int countBracket);

        void CheckAvailability(string input);
    }
}
