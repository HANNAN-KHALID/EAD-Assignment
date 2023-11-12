using System;
using System.Data.Entity;
using System.Linq;

public enum Grade
{
    A, B, C, D, F
}

public class Enrollment
{
    public int EnrollmentID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public Grade? Grade { get; set; }

    public virtual Course Course { get; set; }
    public virtual Student Student { get; set; }
}

public class Student
{
    public int ID { get; set; }
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public DateTime EnrollmentDate { get; set; }

    //two new fields:emailand birt date
    public string EmailAddress { get; set; } 
    public DateTime BirthDate { get; set; }  

    public virtual ICollection<Enrollment> Enrollments { get; set; }
}


public class Course
{
    public int CourseID { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; }
}

public class MyContext : DbContext
{
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Enrollment> Enrollments { get; set; }
    public virtual DbSet<Student> Students { get; set; }
}

class Program
{
    static void Main()
    {
        using (var context = new MyContext())
        {
            Console.WriteLine("Adding new students");

            var newStudent = new Student
            {
                FirstMidName = "Atyia",
                LastName = "Alam",
                EnrollmentDate = DateTime.Today
            };

            context.Students.Add(newStudent);

            var newStudent1 = new Student
            {
                FirstMidName = "Ali",
                LastName = "Ahmed",
                EnrollmentDate = DateTime.Today
            };

            context.Students.Add(newStudent1);
            context.SaveChanges();

            var students = (from s in context.Students
                            orderby s.FirstMidName
                            select s).ToList();

            Console.WriteLine("Retrieve all Students from the database:");

            foreach (var student in students)
            {
                string fullName = $"{student.FirstMidName} {student.LastName}";
                Console.WriteLine("ID: {0}, Name: {1}", student.ID, fullName);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
