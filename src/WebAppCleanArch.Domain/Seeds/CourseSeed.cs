using WebAppCleanArch.Domain.Entities;

namespace WebAppCleanArch.Domain.Seeds;

public static class CourseSeed
{
    public static List<Course> Courses()
    {
        return new List<Course>
        {
            new Course
            {
                CourseName = "Mathematics"
            }
        };
    }
}
