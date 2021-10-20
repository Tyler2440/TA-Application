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
    public class Course
    {
        public int ID { get; set; }
        public string SemesterCourseOffered { get; set; }
        public string YearCourseOffered { get; set; }
        public string CourseTitle { get; set; }
        public int CourseNumber { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }
        public string ProfessoruID { get; set; }
        public string ProfessorName { get; set; }
        public string TimesOffered { get; set; }
        public string Location { get; set; }
        public int CreditHours { get; set; }        
        public int Enrollment { get; set; }
        public string Note { get; set; }
    }
}
