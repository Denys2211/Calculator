using Calculator;
using System;
using System.Collections.Generic;
using System.IO;

namespace Logger
{
    class CalcLogger : ILogger
    {
        readonly string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public CalcLogger()
        {

        }
        public async void WriteFile(string text)
        {
            using var sw = new StreamWriter(folderPath + "Log.txt", true, System.Text.Encoding.Default);
            await sw.WriteLineAsync(text);
        }
        public string ReaderFile()
        {
            using var sr = new StreamReader(folderPath + "Log.txt", System.Text.Encoding.Default);

            return sr.ReadToEnd();
        }

    }
}
