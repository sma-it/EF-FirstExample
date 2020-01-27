using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Colony.SysLog
{
    public enum LogLevel
    {
        Error,
        Warning,
        Debug,
    };

    public class Log
    {
        private static Log instance = null;

        private Log() { }

        public static Log GetInstance()
        {
            if (instance == null)
            {
                instance = new Log();
            }
            return instance;
        }

        public LogLevel LogLevel { get; set; } = LogLevel.Error;

        public void AddError(string text)
        {
            addLine(LogLevel.Error, text);
        }

        public void AddWarning(string text)
        {
            if (LogLevel >= LogLevel.Warning)
            {
                addLine(LogLevel.Warning, text);
            }
        }

        public void AddDebug(string text)
        {
            if (LogLevel >= LogLevel.Debug)
            {
                addLine(LogLevel.Debug, text);
            }
        }

        public void Print()
        {
            String[] lines;
            if (File.Exists("log.txt"))
            {
                lines = File.ReadAllLines("log.txt");
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void Clear()
        {
            File.Delete("log.txt");
        }

        private void addLine(LogLevel logLevel, string text)
        {
            string output = DateTime.Now.ToString();
            switch(logLevel) { 
                case LogLevel.Error: output += " Error: "; break;
                case LogLevel.Warning: output += " Warning: "; break;
                case LogLevel.Debug: output += " Debug: "; break;
            }
            output += text + Environment.NewLine;
            File.AppendAllText("log.txt", output);
        }
    }
}
