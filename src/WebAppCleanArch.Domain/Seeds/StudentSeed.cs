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
            Age = 25
        };
        
        students.Add(student);

        return students;
    }
}