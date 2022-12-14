using HeroApi.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace HeroApi.DataAccess.Contexts;

public sealed class HeroContext : DbContext
{
    public DbSet<Hero> Heroes { get; set; }

    public HeroContext(DbContextOptions options) : base(options)
    {
        // TODO: Mer här sen 
        try
        {
            if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator)
            {
                if (!databaseCreator.CanConnect())
                    databaseCreator.Create();
                if (!databaseCreator.HasTables())
                    databaseCreator.CreateTables();
            }
            //Database.EnsureCreated();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}