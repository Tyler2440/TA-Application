using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAApplication.Controllers
{
    [Authorize(Roles="Administrator")]
    public class AdminController : Controller
    {
        UserManager<IdentityRole> um;

        public AdminController(UserManager<IdentityRole> um)
        {
            this.um = um;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostRole(string userid, string role, bool? enable_disable)
        {
            if (userid == null || role == null || enable_disable == null)
            {
                return BadRequest("Invalid data!");
            }

            if (enable_disable == true)
                await um.AddToRoleAsync(await um.FindByIdAsync(userid), role);
            else
                await um.RemoveFromRoleAsync(await um.FindByIdAsync(userid), role);

            return Ok(new { message = "Success!" });
        }
    }
}
