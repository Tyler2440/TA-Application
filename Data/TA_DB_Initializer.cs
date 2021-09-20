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
            context.Database.EnsureCreated();

            // Look for any applications.
            if (context.Applications.Any())
            {
                return;   // DB has been seeded
            }

            var applications = new Application[]
            {
            new Application{FirstName="Carson",LastName="Alexander",ID=1234567,PhoneNumber="000-000-0001",Address="123 Joy St. Salt Lake City, Utah 812345",
                CurrentDegree="Computer Science",CurrentProgram="BS", GPA=4.0, NumberHours=12,PersonalStatement="Hey there.", 
                fluency = Application.EnglishFluency.Native, SemestersCompleted=4, LinkedInURL="www.linkedin.com", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2005-09-01"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="Ben",LastName="Malhoi",ID=1234568,PhoneNumber="000-000-0002",Address="124 Joy St. Salt Lake City, Utah 812345",
                CurrentDegree="Computer Science",CurrentProgram="BS", GPA=1.0, NumberHours=3,PersonalStatement="My nam is Ben.", 
                fluency = Application.EnglishFluency.None, SemestersCompleted=6, LinkedInURL="www.linkedin.com", ResumeFile="blank", 
                ApplicantPhoto="blank", CreationDate=DateTime.Parse("2021-09-19"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="Tyler",LastName="Allen",ID=1234569,PhoneNumber="000-000-0003",Address="125 Joy St. Salt Lake City, Utah 812345",
                CurrentDegree="Computer Science",CurrentProgram="BS", GPA=4.0, NumberHours=12,PersonalStatement="I like helping people.", 
                fluency = Application.EnglishFluency.Native, SemestersCompleted=4, LinkedInURL="www.linkedin.com", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2021-09-19"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="Dallon",LastName="Haley",ID=1234570,PhoneNumber="000-000-0004",Address="126 Joy St. Salt Lake City, Utah 812345",
                CurrentDegree="Computer Science",CurrentProgram="BS", GPA=3.8, NumberHours=8,PersonalStatement="I like helping people a bit.", 
                fluency = Application.EnglishFluency.Fluent, SemestersCompleted=4, LinkedInURL="www.linkedin.com", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2021-09-19"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="Austin",LastName="Kelley",ID=1234571,PhoneNumber="000-000-0005",Address="127 Joy St. Salt Lake City, Utah 812345",
                CurrentDegree="Computer Science",CurrentProgram="BS", GPA=2.9, NumberHours=15,PersonalStatement="I like helping people a bit more.", 
                fluency = Application.EnglishFluency.Adequate, SemestersCompleted=4, LinkedInURL="www.linkedin.com", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2021-09-19"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="Tanjiro",LastName="Kamado",ID=478961,PhoneNumber="000-500-0001",Address="123 Mad St. Salt Lake City, Utah 812345",
            CurrentDegree="Computer Engineering",CurrentProgram="BS", GPA=4.0, NumberHours=10,PersonalStatement="Hello.",
                fluency = Application.EnglishFluency.None, SemestersCompleted=8, LinkedInURL="www.linkedin.com/tanjiro", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2015-09-01"), ModificationDate=DateTime.Parse("2021-09-22")},

            new Application{FirstName="Zenitsu",LastName="Agatsuma",ID=5798427,PhoneNumber="000-574-0001",Address="123 Scared St. Salt Lake City, Utah 812345",
                CurrentDegree="Computer Science",CurrentProgram="BS", GPA=3.7, NumberHours=10,PersonalStatement="I'm scared.",
                fluency = Application.EnglishFluency.None, SemestersCompleted=7, LinkedInURL="www.linkedin.com/zenitsu", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2015-09-01"), ModificationDate=DateTime.Parse("2021-09-21")},

            new Application{FirstName="Naruto",LastName="Uzumaki",ID=1234567,PhoneNumber="012-000-0001",Address="123 Joy Lane, Salt Lake City, Utah 812345",
                CurrentDegree="Biology",CurrentProgram="BS", GPA=2.1, NumberHours=2,PersonalStatement="Believe it.",
                fluency = Application.EnglishFluency.None, SemestersCompleted=4, LinkedInURL="www.linkedin.com/naruto", ResumeFile="blank", 
                CreationDate=DateTime.Parse("2005-09-01"), ModificationDate=DateTime.Parse("2021-09-20")},

            new Application{FirstName="Sasuke",LastName="Uchiha",ID=7894537,PhoneNumber="000-487-4618",Address="487 Joy Lane. Salt Lake City, Utah 812345",
                CurrentDegree="Art",CurrentProgram="BS", GPA=3.9, NumberHours=20,PersonalStatement="I'm going to restore my clan.",
                fluency = Application.EnglishFluency.None, SemestersCompleted=5, LinkedInURL="www.linkedin.com/sasuke", ResumeFile="blank",
                CreationDate=DateTime.Parse("2015-09-01"), ModificationDate=DateTime.Parse("2021-09-23")},
            };

            foreach (Application s in applications)
            {
                context.Applications.Add(s);
            }
            context.SaveChanges();
        }
    }
}