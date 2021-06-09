using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikKok.Data.Models;

namespace TikKok.Data.Seeding
{
    public class TagsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Videos.Any())
            {
                return;
            }

            await dbContext.Tags.AddAsync(new Tag
            {
                Name = "Porn",
            });

            await dbContext.Tags.AddAsync(new Tag
            {
                Name = "NotPorn",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
