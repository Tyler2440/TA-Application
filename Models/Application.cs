using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TAApplication.Models
{
    public class Application
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public string uID { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CurrentDegree { get; set; }
        public string CurrentProgram { get; set; }
        public double GPA { get; set; }
        public int NumberHours { get; set; }
        public string PersonalStatement { get; set; }    
        public enum EnglishFluency { Native, Fluent, Adequate, Poor, None }
        public EnglishFluency fluency { get; set;}
        public int SemestersCompleted { get; set; }
        public string LinkedInURL { get; set; }
        public string ResumeFile { get; set; }
        public string ApplicantPhoto { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
