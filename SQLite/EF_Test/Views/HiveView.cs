using Colony.models;
using Colony.Views.Partial;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Colony.Views
{
    class HiveView
    {
        public static async Task<Hive> Create()
        {
            Caption.Title("Add Hive");
            List<Queen> queens = await Context.Get.Queens.ToListAsync();

            if (queens.Count == 0)
            {
                Console.WriteLine("You cannot create a hive without a queen!");
                return null;
            }

            ListView.Print(queens);

            var hive = new Hive();
            var queenID = Ask.Value("Queen ID");
            hive.Queen = Context.Get.Queens.Find(queenID);
            hive.Name = Ask.String("Name");

            return hive;
        }

        public static async Task List()
        {
            Caption.Title("All Hives");
            List<Hive> hives = await Context.Get.Hives.ToListAsync();
            if (hives.Count == 0)
            {
                Console.WriteLine("No Hives Found");
                return;
            }

            hives.ForEach(hive =>
            {
                Console.WriteLine(hive);
                Console.WriteLine($" => owned by queen {hive.Queen.Name}");
                Console.WriteLine($" => has {hive.Ants.Count} ants");

                ListView.Print(hive.Ants, "    => ");
                Console.WriteLine();
            });
        }
    }
}
