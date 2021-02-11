
namespace ConsoleApp
{
    class Program
    {
          static void Main()
         {
            IData data = new DataConsole();
            Context context = new Context();
            Calculator calculator = new Calculator(context);
            Audit audit = new Audit();
            CalcFacade ide = new CalcFacade(data, audit, calculator, context);
            User uss = new User();
            uss.Star(ide);
         }
    }
}

