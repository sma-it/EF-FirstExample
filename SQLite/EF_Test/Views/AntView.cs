using Colony.models;
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
            Caption.Title("Add Ant");
            List<Hive> hives = await Context.Get.Hives.ToListAsync();
            if (hives.Count == 0)
            {
                Caption.Error("You cannot add Ants without a Hive");
                return null;
            }

            var ant = new Ant();
            Console.WriteLine("Add a new Ant");
            ant.Name = Ask.String("Name");
            ant.AgeInDays = Ask.Value("Age in Days");
            ant.FavoriteAntGame = Ask.String("Favourite Game");

            return ant;
        }
    }
}
