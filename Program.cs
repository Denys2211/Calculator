
namespace ConsoleApp
{
    class Program
    {
          static void Main()
         {
            Context context = new Context();
            Calculator calculator = new Calculator(context);
            Audit audit = new Audit();
            CalcFacade ide = new CalcFacade(audit, calculator);
            User uss = new User();
            uss.Star(ide);
         }
    }
}

