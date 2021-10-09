using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAApplication.Areas.Identity.Data;

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
