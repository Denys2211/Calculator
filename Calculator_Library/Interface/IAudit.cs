
namespace Calculator
{
    interface IAudit
    {
        int CountBracket { get; }

        int CountNumbers { get; }

        void СheckNumericCharacter(string input, string[] symbol);

        void CheckQuantity(string input);

        void CorrectInput(string input);

        void CheckAvailability(string input);
    }
}
