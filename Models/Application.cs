/*
    Author:    Tyler Allen
    Partner:   Ben Malohi
    Date:      September 27, 2021
    Course: CS 4540, University of Utah, School of Computing
    Copyright: CS 4540 and Tyler Allen, Ben Malohi - This work may not be copied for use in Academic Coursework.
    We, Tyler Allen and Ben Malohi, certify that we wrote this code from scratch and did not copy it in part or whole from
    another source.  Any references used in the completion of the assignment are cited in my README file.
    File Contents
    Represents an application for a TA applicant
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TAApplication.Models
{
    // Holds property values for each required field in an application
    public class Application
    {
        [Required][Range(1,20)]
        public string FirstName { get; set; }
        [Required][Range(1, 20)]
        public string LastName { get; set; }
        public int ID { get; set; }
        [Required][Display(Description = "Please use the form u1234567...")][RegularExpression("^[u]{1}[0-9]{7}$)")]
        public string uID { get; set; }
        [Required][Range(1, 10)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string CurrentDegree { get; set; }
        [Required]
        public string CurrentProgram { get; set; }
        [Required][Range(1, 4)]
        public double GPA { get; set; }
        [Required][Range(1, 2)]
        public int NumberHours { get; set; }
        [Display(Description = "Please input a personal statement in <200 characters...")][Range(1, 200)]
        public string PersonalStatement { get; set; }        
        public enum EnglishFluency { Native, Fluent, Adequate, Poor, None }
        [Required]
        public EnglishFluency fluency { get; set;}
        [Required][Range(1, 3)]
        public int SemestersCompleted { get; set; }
        public string LinkedInURL { get; set; }
        [Required]
        public string ResumeFile { get; set; }
        public string ApplicantPhoto { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
