using Colony.models;
using Colony.SysLog;
using Colony.Views.Partial;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Colony.Views
{
    class AntView
    {
        public static async Task<Ant> Create()
        {
            Log.GetInstance().AddDebug("Enter AntView.Create");
            Caption.Title("Add Ant");
            List<Hive> hives = await Context.Get.Hives.ToListAsync();
            if (hives.Count == 0)
            {
                Log.GetInstance().AddWarning("User Tried to add Ant without having hives");
                Caption.Error("You cannot add Ants without a Hive");
                return null;
            }

            var ant = new Ant();
            Console.WriteLine("Add a new Ant");
            ant.Name = Ask.String("Name");
            ant.AgeInDays = Ask.Value("Age in Days");
            ant.FavoriteAntGame = Ask.String("Favourite Game");
            if (ant.Name == "") Log.GetInstance().AddWarning("Ant Added Without Name");

            return ant;
        }

        public static async Task<Ant> Select()
        {
            Caption.Title("Select an Ant");
            List<Ant> ants = await Context.Get.Ants.ToListAsync();
            if (ants.Count == 0)
            {
                Caption.Error("There Are no Ants");
                return null;
            }
            ListView.Print(ants);

            var antID = Ask.Value("Enter Ant ID");
            
            Ant ant = Context.Get.Ants.Find(antID);
            if (ant == null)
            {
                Log.GetInstance().AddError("Invalid Ant ID: " + antID);
            }
            return ant;
        }

        public static async Task AddToHive(Ant ant)
        {
            Caption.Title("Add Ant to Hive");
            List<Hive> hives = await Context.Get.Hives.ToListAsync();
            if (hives.Count == 0)
            {
                Caption.Error("There Are no Hives");
                return;
            }

            ListView.Print(hives);
            var hiveID = Ask.Value("Enter Hive ID");
            var selectedHive = Context.Get.Hives.Find(hiveID);
            if (selectedHive != null)
            {
                selectedHive.Ants.Add(new AntHiveRelation(ant, selectedHive));
            }
        }

        public static async Task List()
        {
            Caption.Title("All Ants");
            List<Ant> ants = await Context.Get.Ants.ToListAsync();
            if (ants.Count == 0)
            {
                Console.WriteLine("No Ants Found");
                return;
            }

            ants.ForEach(ant =>
            {
                Console.WriteLine(ant);
                Console.WriteLine($" => has {ant.Hives.Count} hives");
                ListView.PrintHives(ant.Hives, "    => ");
                Console.WriteLine();
            });
        }
    }
}
