using App.Domain;
using DAL.App;
using Microsoft.EntityFrameworkCore;

namespace WebApp;

public class AppDataHelper
{
    public static void SetupAppData(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
    {
        using var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();

        using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

        if (context == null)
        {
            throw new ApplicationException("Problem in service");
        }

        if (configuration.GetValue<bool>("DataInitialization:DropDatabase"))
        {
            context.Database.EnsureDeleted();
        }
        
        if (configuration.GetValue<bool>("DataInitialization:MigrateDatabase"))
        {
            context.Database.Migrate();
        }
        // TODO - Check DB state

        if (configuration.GetValue<bool>("DataInitialization:SeedIdentity"))
        {
            // TODO
        }
        
        if (configuration.GetValue<bool>("DataInitialization:SeedData"))
        {
            var test = new TestItem
            {
                Name =
                {
                    ["et-EE"] = "Estonian",
                    ["en-GB"] = "English(Traditional)"
                }
            };
            context.TestItems.Add(test);
            context.SaveChanges();

            var tag1 = new Tag
            {
                Tagname =
                {
                    ["et-EE"] = "Püüton",
                    ["en-GB"] = "Python"
                }
            };
            context.Tags.Add(tag1);
            context.SaveChanges();
            var tag2 = new Tag
            {
                Tagname =
                {
                    ["en-GB"] = "C#"
                }
            };
            context.Tags.Add(tag2);
            var tag3 = new Tag
            {
                Tagname =
                {
                    ["et-EE"] = "Veebirakendus",
                    ["en-GB"] = "WebApp"
                }
            };
            context.Tags.Add(tag3);
            var tag4 = new Tag
            {
                Tagname =
                {
                    ["et-EE"] = "Konsoolirakendus",
                    ["en-GB"] = "Console App"
                }
            };
            context.Tags.Add(tag4);
            var tag5 = new Tag
            {
                Tagname =
                {
                    ["et-EE"] = "Mobiilirakendus",
                    ["en-GB"] = "Mobile App"
                }
            };
            context.Tags.Add(tag5);
            var tag6 = new Tag
            {
                Tagname =
                {
                    ["et-EE"] = "Androidi rakendus",
                    ["en-GB"] = "Android App"
                }
            };
            context.Tags.Add(tag6);
            var tag7 = new Tag
            {
                Tagname =
                {
                    ["et-EE"] = "iOS rakendus",
                    ["en-GB"] = "iOS App"
                }
            };
            context.Tags.Add(tag7);
            var tag8 = new Tag
            {
                Tagname =
                {
                    ["et-EE"] = "Töölauarakendus",
                    ["en-GB"] = "Desktop App"
                }
            };
            context.Tags.Add(tag8);
            var tag9 = new Tag
            {
                Tagname =
                {
                    ["en-GB"] = "Static webpage",
                    ["et-EE"] = "Staatiline veebileht"
                }
            };
            context.Tags.Add(tag9);

            var difficulty = new Difficulty
            {
                Name =
                {
                    ["en-GB"] = "Easy",
                    ["et-EE"] = "Kerge"
                }
            };
            context.Difficulties.Add(difficulty);
            var difficulty1 = new Difficulty
            {
                Name =
                {
                    ["en-GB"] = "Intermediate",
                    ["et-EE"] = "Keskmine"
                }
            };
            context.Difficulties.Add(difficulty1);
            var difficulty2 = new Difficulty
            {
                Name =
                {
                    ["en-GB"] = "Hard",
                    ["et-EE"] = "Raske"
                }
            };
            context.Difficulties.Add(difficulty2);
            
            var complexity = new Complexity
            {
                Name =
                {
                    ["en-GB"] = "Simple",
                    ["et-EE"] = "Lihtne"
                }
            };
            context.Complexities.Add(complexity);
            var complexity1 = new Complexity
            {
                Name =
                {
                    ["en-GB"] = "Small app",
                    ["et-EE"] = "Väike rakendus"
                }
            };
            context.Complexities.Add(complexity1);
            var complexity2 = new Complexity
            {
                Name =
                {
                    ["en-GB"] = "Multy-part system",
                    ["et-EE"] = "Mitmeosaline süsteem"
                }
            };
            context.Complexities.Add(complexity2);
            
            context.SaveChanges();
        }
    }
}