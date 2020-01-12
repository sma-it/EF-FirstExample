using Colony.models;
using Colony.Views;
using Colony.Views.Partial;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colony
{
    class Program
    {
        static void Main(string[] args)
        {
            // Context.Get.Database.EnsureDeleted();
            Context.Get.Database.EnsureCreated();

            var menu = new SMUtils.Menu();

            menu.AddOption('1', "Add Queen", AddQueen);
            menu.AddOption('2', "View Queens", ViewQueens);
            menu.AddOption('3', "Add Hive", AddHive);
            menu.AddOption('4', "View Hives", ViewHives);
            menu.AddOption('5', "Add Ant", AddAnt);
            menu.AddOption('6', "Add Ant To Hive", AddAntToHive);
            menu.AddOption('7', "View Ants", ViewAnts); 
            menu.Start();
        }

        private async static void ViewAnts()
        {
            await AntView.List();
        }

        private async static void AddAntToHive()
        {
            var ant = await AntView.Select();
            if (ant != null)
            {
                await AntView.AddToHive(ant);
                Context.Save();
            }
        }

        private async static void AddAnt()
        {
            var ant = await AntView.Create();
            if (ant == null) return;

            Context.Get.Ants.Add(ant);

            Caption.Title("Available Hives");
            ListView.Print(await Context.Get.Hives.ToListAsync());

            var hiveID = Ask.Value("Enter Hive ID");
            var selectedHive = Context.Get.Hives.Find(hiveID);
            if (selectedHive != null)
            {
                selectedHive.Ants.Add(new AntHiveRelation(ant, selectedHive));
            }
            Context.Save();
        }

        private async static void ViewHives()
        {
            await HiveView.List();
        }

        private async static void AddHive()
        {
            var hive = await HiveView.Create();

            if (hive != null)
            {
                Context.Get.Hives.Add(hive);
                Context.Save();
                Caption.Action($"Hive Added: { hive }");
            } else
            {
                Caption.Action("No Hive Added");
            }
            
        }

        private async static void ViewQueens()
        {
            await QueenView.List();
        }

        private static void AddQueen()
        {
            var queen = QueenView.Create();

            Context.Get.Queens.Add(queen);
            Context.Save();
            Caption.Action($"Queen Added: {queen}");
        }
    }
}
