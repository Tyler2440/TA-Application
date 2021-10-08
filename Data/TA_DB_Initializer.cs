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
    public static class TA_DB_Initializer
    {
        public static void Initialize(TA_DB context)
        {
            // Ensures the database has been created
            context.Database.EnsureCreated();

            // Look for any applications.
            if (context.Applications.Any())
            {
                return;   // DB has been seeded
            }

            // Seeds applications list with many different applicants
            var applications = new Application[]
            {
            new Application{FirstName="u0",LastName="u0", GPA = 0.0, NumberHours = 0, fluency = Application.EnglishFluency.Native, SemestersCompleted = 0,
            CreationDate=DateTime.Parse("2005-09-01"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="u1",LastName="u1",uID="u0000001",PhoneNumber="996-315-5633",Address="123 Joy St. Salt Lake City, Utah 812345",
            CurrentDegree="Computer Science",CurrentProgram="BS", GPA=4.0, NumberHours=12,PersonalStatement="Hey there.",
            fluency = Application.EnglishFluency.Native, SemestersCompleted=4, LinkedInURL="www.linkedin.com", ResumeFile="blank",
            CreationDate=DateTime.Parse("2005-09-01"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="u2",LastName="u2",uID="u0000002",PhoneNumber="996-315-5633",Address="123 Joy St. Salt Lake City, Utah 812345",
            CurrentDegree="Computer Science",CurrentProgram="BS", GPA=4.0, NumberHours=12,PersonalStatement="Hey there.",
            fluency = Application.EnglishFluency.Native, SemestersCompleted=4, LinkedInURL="www.linkedin.com", ResumeFile="blank",
            CreationDate=DateTime.Parse("2005-09-01"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="Bob",LastName="Joe",uID="1234567",PhoneNumber="996-315-5633",Address="123 Joy St. Salt Lake City, Utah 812345",
                CurrentDegree="Computer Science",CurrentProgram="BS", GPA=4.0, NumberHours=12,PersonalStatement="Hey there.", 
                fluency = Application.EnglishFluency.Native, SemestersCompleted=4, LinkedInURL="www.linkedin.com", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2005-09-01"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="Ben",LastName="Malohi",uID="1234568",PhoneNumber="489-138-4563",Address="124 Joy St. Salt Lake City, Utah 812345",
                CurrentDegree="Computer Science",CurrentProgram="BS", GPA=1.0, NumberHours=3,PersonalStatement="My nam is Ben.", 
                fluency = Application.EnglishFluency.None, SemestersCompleted=6, LinkedInURL="www.linkedin.com", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2021-09-19"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="Tyler",LastName="Allen",uID="1234569",PhoneNumber="765-799-8945",Address="125 Joy St. Salt Lake City, Utah 812345",
                CurrentDegree="Computer Science",CurrentProgram="BS", GPA=4.0, NumberHours=12,PersonalStatement="I like helping people.", 
                fluency = Application.EnglishFluency.Native, SemestersCompleted=4, LinkedInURL="www.linkedin.com", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2021-09-19"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="Dallon",LastName="Haley",uID="1234570",PhoneNumber="589-504-0004",Address="126 Joy St. Salt Lake City, Utah 812345",
                CurrentDegree="Computer Science",CurrentProgram="BS", GPA=3.8, NumberHours=8,PersonalStatement="I like helping people a bit.", 
                fluency = Application.EnglishFluency.Fluent, SemestersCompleted=4, LinkedInURL="www.linkedin.com", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2021-09-19"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="Austin",LastName="Kelley",uID="1234571",PhoneNumber="458-569-0005",Address="127 Joy St. Salt Lake City, Utah 812345",
                CurrentDegree="Computer Science",CurrentProgram="BS", GPA=2.9, NumberHours=15,PersonalStatement="I like helping people a bit more.", 
                fluency = Application.EnglishFluency.Adequate, SemestersCompleted=4, LinkedInURL="www.linkedin.com", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2021-09-19"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="Tanjiro",LastName="Kamado",uID="178961",PhoneNumber="624-500-3945",Address="123 Mad St. Salt Lake City, Utah 812345",
            CurrentDegree="Computer Engineering",CurrentProgram="BS", GPA=4.0, NumberHours=10,PersonalStatement="Hello.",
                fluency = Application.EnglishFluency.None, SemestersCompleted=8, LinkedInURL="www.linkedin.com/tanjiro", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2015-09-01"), ModificationDate=DateTime.Parse("2021-09-22")},

            new Application{FirstName="Zenitsu",LastName="Agatsuma",uID="5798427",PhoneNumber="697-574-5148",Address="123 Scared St. Salt Lake City, Utah 812345",
                CurrentDegree="Computer Science",CurrentProgram="BS", GPA=3.7, NumberHours=10,PersonalStatement="I'm scared.",
                fluency = Application.EnglishFluency.None, SemestersCompleted=7, LinkedInURL="www.linkedin.com/zenitsu", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2015-09-01"), ModificationDate=DateTime.Parse("2021-09-21")},

            new Application{FirstName="Naruto",LastName="Uzumaki",uID="123456",PhoneNumber="012-589-5489",Address="123 Joy Lane, Salt Lake City, Utah 812345",
                CurrentDegree="Biology",CurrentProgram="BS", GPA=2.1, NumberHours=2,PersonalStatement="Believe it.",
                fluency = Application.EnglishFluency.None, SemestersCompleted=4, LinkedInURL="www.linkedin.com/naruto", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2005-09-01"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="Sasuke",LastName="Uchiha",uID="7894537",PhoneNumber="156-487-4618",Address="487 Joy Lane. Salt Lake City, Utah 812345",
                CurrentDegree="Art",CurrentProgram="BS", GPA=3.9, NumberHours=20,PersonalStatement="I'm going to restore my clan.",
                fluency = Application.EnglishFluency.None, SemestersCompleted=5, LinkedInURL="www.linkedin.com/sasuke", ResumeFile="blank",
                CreationDate=DateTime.Parse("2015-09-01"), ModificationDate=DateTime.Parse("2021-09-23")},
            };

            // Add each seeded applicant to the database table
            foreach (Application s in applications)
            {
                context.Applications.Add(s);
            }

            context.SaveChanges();
        }
    }
}