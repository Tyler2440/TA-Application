/*
    Author:    Tyler Allen
    Partner:   Ben Malohi
    Date:      September 27, 2021
    Course: CS 4540, University of Utah, School of Computing
    Copyright: CS 4540 and Tyler Allen, Ben Malohi - This work may not be copied for use in Academic Coursework.
    We, Tyler Allen and Ben Malohi, certify that we wrote this code from scratch and did not copy it in part or whole from
    another source.  Any references used in the completion of the assignment are cited in my README file.
    File Contents
    Represents the database for TAApplication, currently only holds a table for applicants
*/
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
