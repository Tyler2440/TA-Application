using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TAApplication.Areas.Identity.Data;

namespace TAApplication.Data
{
    public class TAUsersRolesDB : IdentityDbContext<TAUser>
    {
        public TAUsersRolesDB(DbContextOptions<TAUsersRolesDB> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
