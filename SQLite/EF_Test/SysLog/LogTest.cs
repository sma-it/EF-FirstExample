using System;
using System.Collections.Generic;
using System.Text;

namespace Colony.SysLog
{
    public class LogTest
    {
        static LogTest instance = null;

        SMUtils.Menu menu = new SMUtils.Menu();

        public static LogTest getInstance()
        {
            if (instance == null)
            {
                instance = new LogTest();
            }
            return instance;
        }

        public void Start()
        {
            menu.Start();
        }

        private LogTest()
        {
            menu.AddOption('1', "Set LogLevel to Errors", setLogToError);
            menu.AddOption('2', "Set LogLevel to Warnings", setLogToWarning);
            menu.AddOption('3', "Set LogLevel to Debug", setLogToDebug);
            menu.AddOption('4', "Write Error To Log", addError);
            menu.AddOption('5', "Write Warning To Log", addWarning);
            menu.AddOption('6', "Write Debug To Log", addDebug);
            menu.AddOption('7', "Show Log", print);
            menu.AddOption('8', "Clear Log", clear);
        }

        private void print()
        {
            Log.GetInstance().Print();
            Console.WriteLine("Printing Log");
        }

        private void setLogToError()
        {
            Log.GetInstance().LogLevel = LogLevel.Error;
            Console.WriteLine("Logging Errors Only");
        }

        private void setLogToWarning()
        {
            Log.GetInstance().LogLevel = LogLevel.Warning;
            Console.WriteLine("Logging Errors And Warnings");
        }

        private void setLogToDebug()
        {
            Log.GetInstance().LogLevel = LogLevel.Debug;
            Console.WriteLine("Logging Everything");
        }

        private void clear()
        {
            Log.GetInstance().Clear();
            Console.WriteLine("Cleared Log File");
        }

        private void addError()
        {
            Log.GetInstance().AddError("This is an error");
            Console.WriteLine("Adding Error To Log");
        }

        private void addWarning()
        {
            Log.GetInstance().AddWarning("This is a warning");
            Console.WriteLine("Adding Warning To Log");
        }

        private void addDebug()
        {
            Log.GetInstance().AddDebug("This is Debug Info");
            Console.WriteLine("Adding Debug Info To Log");
        }
    }
}
