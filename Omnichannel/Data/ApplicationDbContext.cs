using Microsoft.EntityFrameworkCore;
using Omnichannel.Models;

namespace Omnichannel.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<CallReason> CallReasons { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<FurtherDetail> FurtherDetails { get; set; }
        public DbSet<CallDriver> CallDrivers { get; set; }
        public DbSet<QueryStatus> QueryStatuses { get; set; }
        public DbSet<SUSIAssistlineInteraction> SUSIAssistlineInteractions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach(var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) 
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}
