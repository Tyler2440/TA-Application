using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TAApplication.Models;

namespace TAApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Displays the HW1_Application page
        public IActionResult HW1_Application()
        {
            return View();
        }

        // Displays the HW2_Edit page
        public IActionResult HW2_Edit()
        {
            return View();
        }

        // Displays the HW2_Index page
        public IActionResult HW2_Index()
        {
            return View();
        }

        // Displays the Privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        // Displays the Index page
        public IActionResult Index()
        {
            return View();
        }

        // Tracks and displays errors
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Handles resume/applicant photo upload (RESUME/PHOTO UPLOADS DO NOT WORK)
        [HttpPost]
        public async Task<IActionResult> FileUpload(List<IFormFile> files)
        {
            try
            {
                if (files.Count != 1) 
                { 
                    return BadRequest(new { message = "Must Submit One File" }); 
                }
                var _config = JObject.Parse(JsonConvert.SerializeObject("configuration.json"));
                long size = files.Sum(f => f.Length); 
                var new_name = ""; 
                var extension = "";
                var filePaths = new List<string>();
                foreach (var formFile in files)
                {
                    // check formFile length to make sure file is a reasonable size
                    if (formFile.Length > 10000000 || formFile.Length == 0)
                        return BadRequest(new { message = "File is too large or is empty. Please upload a file smaller than 10MB." });
              
                    new_name = formFile.FileName;  // warning: really should use a new name!
                    var filePath = Path.Combine(_config["StoreFilePath"].ToString(), Path.GetRandomFileName());
                    // save the file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
                return Ok(new { message = new_name, count = files.Count, size, filePaths });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Something went wrong. Try again later." });
            }           
        }

        [HttpPost]
        public IActionResult OnPost(string userid, string role, bool enable_disable)
        {
            if (userid == null || role == null)
            {
                return BadRequest("Invalid data!");
            }

            if (enable_disable)
            {
                //await um.AddToRoleAsync(await um.FindByIdAsync(userid), role);
                return Ok(new { message = "Success!" });
            }
            else
                //await um.RemoveFromRoleAsync(await um.FindByIdAsync(userid), role);
                return BadRequest("Invalid data!");

            //return Ok(new { message = "Success!" });
        }
    }
}
