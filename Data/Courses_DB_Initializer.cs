/*
    Author:    Tyler Allen
    Partner:   Ben Malohi
    Date:      September 27, 2021
    Course: CS 4540, University of Utah, School of Computing
    Copyright: CS 4540 and Tyler Allen, Ben Malohi - This work may not be copied for use in Academic Coursework.
    We, Tyler Allen and Ben Malohi, certify that we wrote this code from scratch and did not copy it in part or whole from
    another source.  Any references used in the completion of the assignment are cited in my README file.
    File Contents
    Initializes the TAApplication applicant table with seeded values.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAApplication.Models;

namespace TAApplication.Data
{
    public static class Courses_DB_Initializer
    {
        public static void Initialize(Courses_DB context)
        {
            // Ensures the database has been created
            context.Database.EnsureCreated();

            // Look for any applications.
            if (context.Courses.Any())
            {
                return;   // DB has been seeded
            }

            // Seeds applications list with many different applicants
            var courses = new Course[]
            {
            new Course{SemesterCourseOffered="Spring", YearCourseOffered="2022", CourseTitle="Intro To Object-Oriented Programming", Department="CS", CourseNumber=1410,
            Section="001", Description="Introduction to programming", ProfessoruID="u1234568", ProfessorName="Joseph Zachary", TimesOffered="M/W 12:15-1:35",
            Location="WEB L105", CreditHours=3, Enrollment=175, Note="Hello"},
            new Course{SemesterCourseOffered="Spring", YearCourseOffered="2022", CourseTitle="Data Structures and Algorithms", Department="CS", CourseNumber=2420,
            Section="001", Description="You learn some data structures and algorithms", ProfessoruID="u1234569", ProfessorName="Erin Parker", TimesOffered="T/Th 1:45-3:05",
            Location="WEB L106", CreditHours=4, Enrollment=175, Note=""},           
            new Course{SemesterCourseOffered="Spring", YearCourseOffered="2022", CourseTitle="Calculus III", Department="MATH", CourseNumber=3100,
            Section="001", Description="You learn more than you did in Calculus II", ProfessoruID="u1234571", ProfessorName="Ben Malohi", TimesOffered="M/W/F 12:00-3:00",
            Location="MEB 120", CreditHours=4, Enrollment=75, Note=""},
            new Course{SemesterCourseOffered="Spring", YearCourseOffered="2022", CourseTitle="Web Software Architecture", Department="CS", CourseNumber=4540,
            Section="001", Description="You make some web related stuff", ProfessoruID="u1234567", ProfessorName="H. James de St. Germain", TimesOffered="M/W 4:35-5:55",
            Location="WEB L104", CreditHours=4, Enrollment=150, Note=""},
            new Course{SemesterCourseOffered="Spring", YearCourseOffered="2022", CourseTitle="Computer Systems", Department="CS", CourseNumber=4400,
            Section="001", Description="You will not like this class", ProfessoruID="u1234570", ProfessorName="Tyler Allen", TimesOffered="M/W 11:50-1:10",
            Location="WEB L107", CreditHours=4, Enrollment=150, Note=""},
            };

            // Add each seeded applicant to the database table
            foreach (Course s in courses)
            {
                context.Courses.Add(s);
            }

            context.SaveChanges();
        }
    }
}