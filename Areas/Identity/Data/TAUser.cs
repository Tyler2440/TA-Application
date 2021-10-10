using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

/*
    Author:    Tyler Allen
    Partner:   Ben Malohi
    Date:      October 10, 2021
    Course: CS 4540, University of Utah, School of Computing
    Copyright: CS 4540 and Tyler Allen, Ben Malohi - This work may not be copied for use in Academic Coursework.
    We, Tyler Allen and Ben Malohi, certify that we wrote this code from scratch and did not copy it in part or whole from
    another source.  Any references used in the completion of the assignment are cited in my README file.
    File Contents
    Holds the properties for a TAUser.
*/
namespace TAApplication.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the TAUser class
    public class TAUser : IdentityUser
    {
        public string Name { get; set; }
        public string uID { get; set; }
        public bool HasApplication { get; set; }
    }
}
