using Colony.SysLog;
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
            Context.Get.Database.EnsureDeleted();
            Context.Get.Database.EnsureCreated();

            var menu = new SMUtils.Menu();

            menu.AddOption('1', "Add Queen", AddQueen);
            menu.AddOption('2', "View Queens", ViewQueens);
            menu.AddOption('3', "Add Hive", AddHive);
            menu.AddOption('4', "View Hives", ViewHives);
            menu.AddOption('5', "Add Ant", AddAnt);
            menu.AddOption('6', "Add Ant To Hive", AddAntToHive);
            menu.AddOption('7', "View Ants", ViewAnts);
            menu.AddOption('8', "Test Log", TestLog);
            menu.Start();
        }

        private static void TestLog()
        {
            LogTest.getInstance().Start();
        }

        private async static void ViewAnts()
        {
            Log.GetInstance().AddDebug("Enter ViewAnts");
            await AntView.List();
            Log.GetInstance().AddDebug("Exit ViewAnts");
        }

        private async static void AddAntToHive()
        {
            Log.GetInstance().AddDebug("Enter AddAntToHive");
            var ant = await AntView.Select();
            if (ant != null)
            {
                Log.GetInstance().AddDebug("Got Ant. Adding to Hive now.");
                await AntView.AddToHive(ant);
                Context.Save();
            } else
            {
                Log.GetInstance().AddWarning("No Ant Selected");
            }
            Log.GetInstance().AddDebug("Exit AddAntToHive");
        }

        private async static void AddAnt()
        {
            Log.GetInstance().AddDebug("Enter AddAnt");
            var ant = await AntView.Create();
            if (ant == null)
            {
                Log.GetInstance().AddWarning("AntView.Create returned null");
                return;
            }

            Context.Get.Ants.Add(ant);
            Context.Save();

            await AntView.AddToHive(ant);
            Context.Save();
            Log.GetInstance().AddDebug("Exit AddAnt");
        }

        private async static void ViewHives()
        {
            Log.GetInstance().AddDebug("Enter ViewHives");
            await HiveView.List();
            Log.GetInstance().AddDebug("Exit ViewHives");
        }

        private async static void AddHive()
        {
            Log.GetInstance().AddDebug("Enter AddHive");
            var hive = await HiveView.Create();

            if (hive != null)
            {
                Context.Get.Hives.Add(hive);
                Context.Save();
                Caption.Action($"Hive Added: { hive }");
            } else
            {
                Caption.Action("No Hive Added");
                Log.GetInstance().AddWarning("HiveView.Create returned null");
            }
            Log.GetInstance().AddDebug("Exit AddHive");
        }

        private async static void ViewQueens()
        {
            Log.GetInstance().AddDebug("Enter ViewQueens");
            await QueenView.List();
            Log.GetInstance().AddDebug("Exit ViewQueens");
        }

        private static void AddQueen()
        {
            Log.GetInstance().AddDebug("Enter AddQueen");
            var queen = QueenView.Create();

            Context.Get.Queens.Add(queen);
            Context.Save();
            Caption.Action($"Queen Added: {queen}");
            Log.GetInstance().AddDebug("Exit AddQueen");
        }
    }
}
