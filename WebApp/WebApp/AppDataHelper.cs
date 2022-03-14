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
        }
    }
}