using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TAApplication.Models;

namespace TAApplication.Data
{
    public class TA_DB : DbContext
    {
        public TA_DB(DbContextOptions<TA_DB> context) : base(context)
        {
        }

        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().ToTable("Application");
        }
    }
}
