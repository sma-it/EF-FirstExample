using Colony.models;
using Colony.SysLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colony.Views.Partial
{
    class ListView
    {
        public static void Print(IEnumerable<object> list, string prefix = "")
        {
            Log.GetInstance().AddDebug("Enter ListView.Print");
            foreach (var item in list)
            {
                Console.WriteLine(prefix + item);
            }
            Log.GetInstance().AddDebug("Exit ListView.Print");
        }

        public static void PrintAnts(IEnumerable<AntHiveRelation> list, string prefix = "")
        {
            Log.GetInstance().AddDebug("Enter ListView.PrintAnts");
            foreach (AntHiveRelation item in list)
            {
                Console.WriteLine(prefix + item.Ant);
            }
            Log.GetInstance().AddDebug("Exit ListView.PrintAnts");
        }

        public static void PrintHives(IEnumerable<AntHiveRelation> list, string prefix = "")
        {
            Log.GetInstance().AddDebug("Enter ListView.PrintHives");
            foreach (AntHiveRelation item in list)
            {
                Console.WriteLine(prefix + item.Hive);
            }
            Log.GetInstance().AddDebug("Exit ListView.PrintHives");
        }
    }
}
