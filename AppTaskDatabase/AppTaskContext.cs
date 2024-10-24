using AppTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTaskDatabase
{
    public class AppTaskContext : DbContext
    {

        public DbSet <TaskModel> Task { get; set; }

        public DbSet <SubTaskModel> SubPropertys { get; set; }
        public AppTaskContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "appTaks.db");  

            optionsBuilder.UseSqlite($"Filename = {databasePath}");
            //Database.Migrate();
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


    }
}
