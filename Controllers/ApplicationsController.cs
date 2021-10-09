using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TAApplication.Areas.Identity.Data;
using TAApplication.Data;
using TAApplication.Models;
/*
    Author:    Tyler Allen
    Partner:   Ben Malohi
    Date:      September 27, 2021
    Course: CS 4540, University of Utah, School of Computing
    Copyright: CS 4540 and Tyler Allen, Ben Malohi - This work may not be copied for use in Academic Coursework.
    We, Tyler Allen and Ben Malohi, certify that we wrote this code from scratch and did not copy it in part or whole from
    another source.  Any references used in the completion of the assignment are cited in my README file.
    File Contents
    Controls the index/list/details/etc. pages for Views/Applications. Also handles edit/delete/create/etc. functions that talk to database
*/
namespace TAApplication.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly TA_DB _context;
        private UserManager<TAUser> um;

        public ApplicationsController(UserManager<TAUser> um, TA_DB context)
        {
            this.um = um;
            _context = context;
        }


        // Displays the Index page with all of the applicants asynchronously via Applicants.ToListAsync()
        public async Task<IActionResult> Index()
        {
            return View(await _context.Applications.ToListAsync());
        }

        [Authorize (Roles ="Administrator")]
        // Displays the List page with all of the applicants asynchronously via Applicants.ToListAsync()
        public async Task<IActionResult> List()
        {
            return View(await _context.Applications.ToListAsync());
        }

        [Authorize (Roles = "Administrator, Applicant")]
        // Displays the Details page for an applicant according to their id in the database. Fetches their application then displays it
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .FirstOrDefaultAsync(m => m.ID == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        [Authorize(Roles = "Administrator, Applicant")]
        // Displays the Create applicant page
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator, Applicant")]
        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,ID,PhoneNumber,Address,CurrentDegree,CurrentProgram,GPA,NumberHours," +
            "PersonalStatement,SemestersCompleted,LinkedInURL,ResumeFile,CreationDate,ModificationDate, UserID")] Application application)
        {
            if (ModelState.IsValid)
            {
                TAUser user = await um.GetUserAsync(User);
                application.UserID = user.Id;
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(application);
        }

        [Authorize(Roles = "Applicant")]
        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .FirstOrDefaultAsync(m => m.ID == id);
            if (application == null)
            {
                return NotFound();
            }

            TAUser user = await um.GetUserAsync(User);

            if (user.uID == application.uID)
            {                             
                return View(application);
            }
            application = await _context.Applications.FirstOrDefaultAsync(m => m.uID == user.uID);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id, [Bind("FirstName,LastName,ID,PhoneNumber,Address,CurrentDegree,CurrentProgram,GPA,NumberHours," +
            "PersonalStatement,SemestersCompleted,LinkedInURL,ResumeFile,CreationDate,ModificationDate")] Application application)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationToUpdate = await _context.Applications.FirstOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Application>(
                    applicationToUpdate, "", s => s.FirstName, s => s.LastName, s => s.CreationDate, s=>s.Address, s=>s.ApplicantPhoto, s=>s.CreationDate, s=>s.CurrentDegree, s=>s.CurrentProgram,
                    s=>s.fluency, s=>s.GPA, s=>s.LinkedInURL, s=>s.ModificationDate, s=>s.NumberHours, s=>s.PersonalStatement, s=>s.PhoneNumber, s=>s.ResumeFile, s=>s.SemestersCompleted, s=>s.uID))
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateException)
                    {
                        ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                    }
                }
            }
            return View(applicationToUpdate);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Applications
                .FirstOrDefaultAsync(m => m.ID == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.ID == id);
        }
    }
}
