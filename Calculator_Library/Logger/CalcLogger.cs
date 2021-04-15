using Calculator;
using System.Collections.Generic;
using System.IO;

namespace Logger
{
    class CalcLogger : ILogger
    {
        readonly string path = @"D:\CalculatorXXI\";

        readonly string subpath = @"Logger\";

        public CalcLogger()
        {
            CreateDirectory();
        }

        private void CreateDirectory()
        {

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
        }
       public async void WritteFile(string text)
        {
            using StreamWriter sw = new StreamWriter(path+subpath+"Log.txt", true, System.Text.Encoding.Default);

            await sw.WriteLineAsync(text);
        }
        public string ReaderFile()
        {
            using StreamReader sr = new StreamReader(path + subpath + "Log.txt", System.Text.Encoding.Default);

            return sr.ReadToEnd();
        }

    }
}
