using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAApplication.Controllers
{
    public class AdminController : Controller
    {
        UserManager<IdentityRole> um;

        public AdminController(UserManager<IdentityRole> um)
        {
            this.um = um;
        }

        [HttpPost]
        public async Task<IActionResult> OnRolePost(string id, string role, bool? enabled)
        {
            if (id == null || role == null || enabled == null)
            {
                return BadRequest("Invalid data!");
            }

            if (enabled == true)
                await um.AddToRoleAsync(await um.FindByIdAsync(id), role);
            else
                await um.RemoveFromRoleAsync(await um.FindByIdAsync(id), role);

            return Ok(new { message = "Success!" });
        }
    }
}
