using Colony.models;
using Colony.Views.Partial;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Colony.Views
{
    class QueenView
    {
        public static Queen Create()
        {
            Caption.Title("Add Queen");
            var queen = new Queen();
            queen.Name = Ask.String("Name");
            queen.AgeInDays = Ask.Value("Age in Days");

            return queen;
        }

        public async static Task List()
        {
            Caption.Title("View All Queens");
            List<Queen> queens = await Context.Get.Queens.ToListAsync();

            if (queens.Count == 0)
            {
                Console.WriteLine("There are no Queens");
                return;
            }

            ListView.Print(queens);
        }
    }
}
