using System.Reflection.Metadata;
using WebAppCleanArch.Domain.Entities;

namespace WebAppCleanArch.Domain.Seeds;

public static class StudentSeed
{
    public static List<Student> Students()
    {
        List<Student> students = new List<Student>();
        
        var student = new Student
        {
            Name = "David Octavyanto",
            Email = "davidocta000@gmail.com",
            Age = 25,
            Courses = new List<Course>
            {
                new Course { CourseName = "Mathematics" },
                new Course { CourseName = "Computer Science" }
            }
        };
        
        students.Add(student);

        return students;
    }
}