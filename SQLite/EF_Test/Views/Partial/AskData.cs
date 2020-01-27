using Colony.SysLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colony.Views.Partial
{
    static class Ask
    {
        public static string String(string label)
        {
            Log.GetInstance().AddDebug("Enter Ask.String");
            Console.Write(label + ": ");
            return Console.ReadLine();

        }

        public static int Value(string label)
        {
            Log.GetInstance().AddDebug("Enter Ask.Value");
            return Convert.ToInt32(String(label));
        }
    }
}
