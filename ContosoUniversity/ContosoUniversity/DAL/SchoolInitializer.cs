using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ContosoUniversity.Models;
namespace ContosoUniversity.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)     
        {           
            var students = new List<Student>        
        {           
            new Student{FirstMidName="Carson",LastName="Alexander",Enrollmentdate=DateTime.Parse("2005-09-01")},  
            new Student{FirstMidName="Meredith",LastName="Alonso",Enrollmentdate=DateTime.Parse("2002-09-01")},         
            new Student{FirstMidName="Arturo",LastName="Anand",Enrollmentdate=DateTime.Parse("2003-09-01")},          
            new Student{FirstMidName="Gytis",LastName="Barzdukas",Enrollmentdate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Yan",LastName="Li",Enrollmentdate=DateTime.Parse("2002- 09-01")},   
            new Student{FirstMidName="Peggy",LastName="Justice",Enrollmentdate=DateTime.Parse ("2001-09-01")},    
            new Student{FirstMidName="Laura",LastName="Norman",Enrollmentdate=DateTime.Parse( "2003-09-01")},     
            new Student{FirstMidName="Nino",LastName="Olivetto",Enrollmentdate=DateTime.Parse ("2005-09-01")}    
        };  
            students.ForEach(s => context.Students.Add(s));      
            context.SaveChanges();         
            var courses = new List<Course>    
            {            
                new Course{CourseID=1050,title="Chemistry",Credits=3,},     
                new Course{CourseID=4022,title="Microeconomics",Credits=3,},  
                new Course{CourseID=4041,title="Macroeconomics",Credits=3,},   
                new Course{CourseID=1045,title="Calculus",Credits=4,},          
                new Course{CourseID=3141,title="Trigonometry",Credits=4,},      
                new Course{CourseID=2021,title="Composition",Credits=3,},           
                new Course{CourseID=2042,title="Literature",Credits=4,}            
            };            
            courses.ForEach(s => context.Courses.Add(s));    
            context.SaveChanges();            
            var enrollments = new List<Enrollment>     
            {             
                new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},  
                new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},   
                new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},       
                new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},   
                new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},       
                new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},   
                new Enrollment{StudentID=3,CourseID=1050},             
                new Enrollment{StudentID=4,CourseID=1050,},          
                new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F}, 
                new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C}, 
                new Enrollment{StudentID=6,CourseID=1045},          
                new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A}, 
            };           
            enrollments.ForEach(s => context.Enrollments.Add(s)); 
            context.SaveChanges();        
        }
    }
}