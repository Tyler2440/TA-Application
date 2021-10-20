using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAApplication.Areas.Identity.Data;
using TAApplication.Data;

/*
    Author:    Tyler Allen
    Partner:   Ben Malohi
    Date:      October 10, 2021
    Course: CS 4540, University of Utah, School of Computing
    Copyright: CS 4540 and Tyler Allen, Ben Malohi - This work may not be copied for use in Academic Coursework.
    We, Tyler Allen and Ben Malohi, certify that we wrote this code from scratch and did not copy it in part or whole from
    another source.  Any references used in the completion of the assignment are cited in my README file.
    File Contents
    This file controls the initialization of the webpage/database.
*/
namespace TAApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }

        private async static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<TA_DB>();
                    TA_DB_Initializer.Initialize(context);

                    UserManager<TAUser> um = services.GetRequiredService<UserManager<TAUser>>();
                    RoleManager<IdentityRole> rm = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var context2 = services.GetRequiredService<TAUsersRolesDB>();
                    await SeedUsersRolesDB.Initialize(rm, um, context2);

                    var context3 = services.GetRequiredService<Courses_DB>();
                    Courses_DB_Initializer.Initialize(context3);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
