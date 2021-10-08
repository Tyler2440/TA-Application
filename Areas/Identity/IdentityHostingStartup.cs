using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TAApplication.Areas.Identity.Data;
using TAApplication.Data;

[assembly: HostingStartup(typeof(TAApplication.Areas.Identity.IdentityHostingStartup))]
namespace TAApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TAUsersRolesDB>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TAUsersRolesDBConnection")));

                services.AddDefaultIdentity<TAUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<TAUsersRolesDB>();

                services.Configure<IdentityOptions>(options =>
                {
                    // Default Password settings.
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;
                });
            });
        }
    }
}