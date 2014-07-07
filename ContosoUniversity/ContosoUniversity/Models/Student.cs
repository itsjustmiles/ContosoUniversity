using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set;} 
        public String LastName {get; set;}
        public string FirstMidName { get; set; }
        public DateTime Enrollmentdate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        
    }
}