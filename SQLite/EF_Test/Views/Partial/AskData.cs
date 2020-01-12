using System;
using System.Collections.Generic;
using System.Text;

namespace Colony.Views.Partial
{
    static class Ask
    {
        public static string String(string label)
        {
            Console.Write(label + ": ");
            return Console.ReadLine();
        }

        public static int Value(string label)
        {
            return Convert.ToInt32(String(label));
        }
    }
}
