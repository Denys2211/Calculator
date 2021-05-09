using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    interface ILogger
    {
        void WriteFile(string text);

        string ReaderFile();

        void CleanLog();
    }
}
