using Colony.SysLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colony.Views.Partial
{
    class Caption
    {
        public static void Title(string label)
        {
            Log.GetInstance().AddDebug("Enter Caption.Title");
            Console.WriteLine("**");
            Console.WriteLine($"** {label}");
            Console.WriteLine("**");
            Console.WriteLine("");
            Log.GetInstance().AddDebug("Exit Caption.Title");
        }

        public static void Action(string label)
        {
            Log.GetInstance().AddDebug("Enter Caption.Action");
            Console.WriteLine($" ... {label}");
            Log.GetInstance().AddDebug("Exit Caption.Action");
        }

        public static void Error(string label)
        {
            Log.GetInstance().AddDebug("Enter Caption.Error");
            Console.WriteLine($"!!! {label} !!!");
            Log.GetInstance().AddDebug("Exit Caption.Error");
        }
    }
}
