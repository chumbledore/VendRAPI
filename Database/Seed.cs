using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Database
{
    public class Seed
    {

        public static async Task SeedData(DataContext context)
        {
            if (context.Beverages.Any()) return;

            var beverages = new List<Beverage>
            {
                new Beverage
                {
                    BevName = "Coca-Cola",
                    Price = 1.50m,
                    Size = 20
                },
                new Beverage
                {
                    BevName = "Mountain Dew",
                    Price = 1.50m,
                    Size = 20
                },
                new Beverage
                {
                    BevName = "Dr. Pepper",
                    Price = 1.50m,
                    Size = 20
                },
                new Beverage
                {
                    BevName = "Pepsi",
                    Price = 1.50m,
                    Size = 20
                },
                new Beverage
                {
                    BevName = "Sun Drop",
                    Price = 1.50m,
                    Size = 20
                }
            };

            await context.Beverages.AddRangeAsync(beverages);
            await context.SaveChangesAsync();
        }
    }
}