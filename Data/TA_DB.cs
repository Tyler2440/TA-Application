using Microsoft.EntityFrameworkCore;
using TAApplication.Models;

namespace TAApplication.Data
{
    public class TA_DB : DbContext
    {
        public TA_DB(DbContextOptions<TA_DB> context) : base(context)
        {
        }

        // Represents the database table for all the applications
        public DbSet<Application> Applications { get; set; }

        // Builds the Applications DBSet to the Application table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().ToTable("Application");
        }
    }
}
