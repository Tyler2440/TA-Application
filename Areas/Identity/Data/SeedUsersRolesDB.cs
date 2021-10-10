using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    Controls the initialization/seeding of the role database.
*/
namespace TAApplication.Areas.Identity.Data
{
    public class SeedUsersRolesDB
    {
        public static async Task Initialize(RoleManager<IdentityRole> rm, UserManager<TAUser> um, TAUsersRolesDB context)
        {
            context.Database.EnsureCreated();

            // Look for any applications.
            if (rm.Roles.ToList().Count >= 3 && um.Users.Count() > 3)
            {
                return;   // DB has been seeded
            }

            await rm.CreateAsync(new IdentityRole("Administrator"));
            await rm.CreateAsync(new IdentityRole("Professor"));
            await rm.CreateAsync(new IdentityRole("Applicant"));

            TAUser admin = new TAUser { UserName = "admin@utah.edu", Name = "admin", Email = "admin@utah.edu", EmailConfirmed = true, HasApplication = false };
            IdentityResult r1 = um.CreateAsync(admin, "123ABC!@#def").Result;

            if (r1.Succeeded)
            {
                await um.AddToRoleAsync(admin, "Administrator");
            }

            TAUser professor = new TAUser { UserName = "professor@utah.edu", Name = "professor", Email = "professor@utah.edu", EmailConfirmed = true, HasApplication = false };
            IdentityResult r2 = um.CreateAsync(professor, "123ABC!@#def").Result;

            if (r2.Succeeded)
            {
                await um.AddToRoleAsync(professor, "Professor");
            }

            TAUser applicant1 = new TAUser { UserName = "u0000000@utah.edu", Name = "applicant1", uID = "u0000000", Email = "u0000000@utah.edu", EmailConfirmed = true, HasApplication = false};
            IdentityResult r3 = um.CreateAsync(applicant1, "123ABC!@#def").Result;

            if (r3.Succeeded)
            {
                await um.AddToRoleAsync(applicant1, "Applicant");
            }

            TAUser applicant2 = new TAUser { UserName = "u0000001@utah.edu", Name = "applicant2", uID = "u0000001", Email = "u0000001@utah.edu", EmailConfirmed = true, HasApplication = true };
            IdentityResult r4 = um.CreateAsync(applicant2, "123ABC!@#def").Result;

            if (r4.Succeeded)
            {
                await um.AddToRoleAsync(applicant2, "Applicant");
            }

            TAUser applicant3 = new TAUser { UserName = "u0000002@utah.edu", Name = "applicant3", uID = "u0000002", Email = "u0000002@utah.edu", EmailConfirmed = true, HasApplication = true };
            IdentityResult r5 = um.CreateAsync(applicant3, "123ABC!@#def").Result;

            if (r5.Succeeded)
            {
                await um.AddToRoleAsync(applicant3, "Applicant");
            }

            //// Seeds applications list with many different applicants
            //var applicants = new TAUser[]
            //{

            //new TAUser{Email="benmalohi@umail.com", PasswordHash="heyImBen"},
            //new TAUser{Email="benmalohi@umail.com", PasswordHash="heyImBen"},
            //new TAUser{Email="benmalohi@umail.com", PasswordHash="heyImBen"},
            //new TAUser{Email="bobjoe@umail.com", PasswordHash="heyImBob"},
            //new TAUser{Email="benmalohi@umail.com", PasswordHash="heyImBen"},
            //new TAUser{Email="tylerallen@umail.com", PasswordHash="heyImTyler"},
            //new TAUser{Email="dallonhaley@umail.com", PasswordHash="heyImDallon"},
            //new TAUser{Email="austinkelley@umail.com", PasswordHash="heyImAustin"},
            //new TAUser{Email="tanjiro@umail.com", PasswordHash="heyImTanjiro"},
            //new TAUser{Email="zenitsu@umail.com", PasswordHash="heyImZenitsu"},
            //new TAUser{Email="naruto@umail.com", PasswordHash="heyImNaruto"},
            //new TAUser{Email="sasuke@umail.com", PasswordHash="heyImSasuke"},
            //};

            //// Add each seeded applicant to the database table
            //foreach (TAUser s in um.Users)
            //{
            //    context.Users.Add(s);
            //}

            context.SaveChanges();
        }
    }
}