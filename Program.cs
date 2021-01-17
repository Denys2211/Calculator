
namespace ConsoleApp2
{
    class Program
    {
          static void Main()
         {
            Calculator calculator = new Calculator();
            Audit audit = new Audit();
            CalcFacade ide = new CalcFacade(audit, calculator);
            User uss = new User();
            uss.Star(ide);
         }
    }
}

