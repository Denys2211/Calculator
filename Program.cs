using AppData;
using Audit;
using InterpreterCalc;
using Microsoft.Data.Sqlite;
using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqliteConnection("Data Source=usersdata.db");
            IData data = new DataConsole(connection);
            IAudit audit = new Audit_Input();
            IContext context = new Context();
            ICalculator exp_evaluate = new Calc_ExpParentheses(context);
            var ide = new CalcFacade(data, audit, exp_evaluate, context);
            var user = new User(ide);
            user.Operation();
        }
    }
}
