namespace ContosoUniversity.Migrations
{
    using ContosoUniversity.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContosoUniversity.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(ContosoUniversity.DAL.SchoolContext context)
        {
            var students = new List<Student>         
            {                
                new Student 
                { 
                    FirstMidName = "Carson",   LastName = "Alexander",       
                    Enrollmentdate = DateTime.Parse("2010-09-01") },  
             
                    new Student 
                    { 
                        FirstMidName = "Meredith", LastName = "Alonso",             
                        Enrollmentdate = DateTime.Parse("2012-09-01") },               
                        new Student
                        { 
                            FirstMidName = "Arturo",   LastName = "Anand",                   
                            Enrollmentdate = DateTime.Parse("2013-09-01") }, 
                            new Student { FirstMidName = "Gytis",    LastName = "Barzdukas",     
                                Enrollmentdate = DateTime.Parse("2012-09-01") },           
                                new Student { FirstMidName = "Yan",      LastName = "Li",      
                                    Enrollmentdate = DateTime.Parse("2012-09-01") },          
                                    new Student { FirstMidName = "Peggy",    LastName = "Justice",                      
                                        Enrollmentdate = DateTime.Parse("2011-09-01") },           
                                        new Student { FirstMidName = "Laura",    LastName = "Norman",                   
                                            Enrollmentdate = DateTime.Parse("2013-09-01") },          
                                            new Student { FirstMidName = "Nino",     LastName = "Olivetto",               
                                                Enrollmentdate = DateTime.Parse("2005-08-11") } 
            };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();
            var courses = new List<Course>           
            {         
                new Course {CourseID = 1050, title = "Chemistry",   Credits = 3, },            
                new Course {CourseID = 4022, title = "Microeconomics", Credits = 3, },                
                new Course {CourseID = 4041, title = "Macroeconomics", Credits = 3, },        
                new Course {CourseID = 1045, title = "Calculus",       Credits = 4, },                
                new Course {CourseID = 3141, title = "Trigonometry",   Credits = 4, },                
                new Course {CourseID = 2021, title = "Composition",    Credits = 3, },         
                new Course {CourseID = 2042, title = "Literature",     Credits = 4, }            
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.title, s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>          
            {  
                new Enrollment 
                {               
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,                     
                    CourseID = courses.Single(c => c.title == "Chemistry" ).CourseID,                 
                    Grade = Grade.A                  },                 
                    new Enrollment {               
                        StudentID = students.Single(s => s.LastName == "Alexander").ID,                
                        CourseID = courses.Single(c => c.title == "Microeconomics" ).CourseID,         
                        Grade = Grade.C               
                    },                                           
                        new Enrollment
                        {                   
                            StudentID = students.Single(s => s.LastName == "Alexander").ID,              
                            CourseID = courses.Single(c => c.title == "Macroeconomics" ).CourseID,            
                            Grade = Grade.B            
                        },                  new Enrollment {                      
                            StudentID = students.Single(s => s.LastName == "Alonso").ID,                 
                            CourseID = courses.Single(c => c.title == "Calculus" ).CourseID,              
                            Grade = Grade.B              
                        },                
                        new Enrollment {                     
                            StudentID = students.Single(s => s.LastName == "Alonso").ID,                
                            CourseID = courses.Single(c => c.title == "Trigonometry" ).CourseID,                
                            Grade = Grade.B          
                        },                  new Enrollment
                        {                  
                            StudentID = students.Single(s => s.LastName == "Alonso").ID,             
                                CourseID = courses.Single(c => c.title == "Composition" ).CourseID,              
                                Grade = Grade.B              
                        },                 
                        new Enrollment 
                        {                    
                            StudentID = students.Single(s => s.LastName == "Anand").ID,        
                            CourseID = courses.Single(c => c.title == "Chemistry" ).CourseID              
                        },                 
                        new Enrollment
                        {                  
                            StudentID = students.Single(s => s.LastName == "Anand").ID,                   
                            CourseID = courses.Single(c => c.title == "Microeconomics").CourseID,             
                            Grade = Grade.B                         
                    },        
                    new Enrollment 
                    {    
                    StudentID = students.Single(s => s.LastName == "Barzdukas").ID,                
                    CourseID = courses.Single(c => c.title == "Chemistry").CourseID,                
                    Grade = Grade.B                        
                    },                
                    new Enrollment
                    {                   
                        StudentID = students.Single(s => s.LastName == "Li").ID,           
                        CourseID = courses.Single(c => c.title == "Composition").CourseID,           
                        Grade = Grade.B                     
                    },               
                    new Enrollment
                    {       
                        StudentID = students.Single(s => s.LastName == "Justice").ID,   
                        CourseID = courses.Single(c => c.title == "Literature").CourseID, 
                        Grade = Grade.B                       
                    }   
            };
            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(s => s.Student.ID == e.StudentID && s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}