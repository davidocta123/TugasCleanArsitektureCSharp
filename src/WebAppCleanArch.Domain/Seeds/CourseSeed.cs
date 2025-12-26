using System.Reflection.Metadata;
using WebAppCleanArch.Domain.Entities;

namespace WebAppCleanArch.Domain.Seeds;

public static class CourseSeed
{
    public static List<Course> Courses()
    {
        List<Course> courses = new List<Course>();
        
        var course = new Course
        {
            CourseName = "Mathematics",
            StudentId = 1
            
        };
        
        
        courses.Add(course);

        return courses;
    }
}
    