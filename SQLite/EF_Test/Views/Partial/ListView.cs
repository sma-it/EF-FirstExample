using Colony.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colony.Views.Partial
{
    class ListView
    {
        public static void Print(IEnumerable<object> list, string prefix = "")
        {
            foreach(var item in list)
            {
                Console.WriteLine(prefix + item);
            }
        }

        public static void PrintAnts(IEnumerable<AntHiveRelation> list, string prefix = "")
        {
            foreach (AntHiveRelation item in list)
            {
                Console.WriteLine(prefix + item.Ant);
            }
        }

        public static void PrintHives(IEnumerable<AntHiveRelation> list, string prefix = "")
        {
            foreach (AntHiveRelation item in list)
            {
                Console.WriteLine(prefix + item.Hive);
            }
        }
    }
}
