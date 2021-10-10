using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAApplication.Areas.Identity.Data;

/*
    Author:    Tyler Allen
    Partner:   Ben Malohi
    Date:      October 10, 2021
    Course: CS 4540, University of Utah, School of Computing
    Copyright: CS 4540 and Tyler Allen, Ben Malohi - This work may not be copied for use in Academic Coursework.
    We, Tyler Allen and Ben Malohi, certify that we wrote this code from scratch and did not copy it in part or whole from
    another source.  Any references used in the completion of the assignment are cited in my README file.
    File Contents
    Controls the OnPost to update the database when roles are updated.
*/
namespace TAApplication.Controllers
{
    [Authorize(Roles="Administrator")]
    public class AdminController : Controller
    {
        UserManager<TAUser> um;
        RoleManager<IdentityRole> rm;

        public AdminController(UserManager<TAUser> um)
        {
            this.um = um;
        }

        [HttpPost]
        public async Task<IActionResult> OnPost(string userid, string role, bool enable_disable)
        {
            if (userid == null || role == null)
            {
                return BadRequest("Invalid data!");
            }

            if (enable_disable)
            {
                await um.AddToRoleAsync(await um.FindByIdAsync(userid), role);
            }
            else
            {
                int adminusers = um.GetUsersInRoleAsync("Administrator").Result.Count;
                if(role == "Administrator" && adminusers - 1 == 0)
                {
                    return BadRequest("No administrators left in database!");
                }
                await um.RemoveFromRoleAsync(await um.FindByIdAsync(userid), role);
            }

            return Ok(new { message = "Success!" });
        }
    }
}
