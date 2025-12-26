using WebAppCleanArch.Domain.Seeds;
using WebAppCleanArch.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace WebAppCleanArch.Infrastructure.Persistence;

public static class ApplicationDbInitializer
{
    public static async Task InitializeAsync(ApplicationDbContext context)
    {
        await context.Database.MigrateAsync();

        await SeedStudentsAsync(context);
        await SeedCoursesAsync(context);
    }

    private static async Task SeedStudentsAsync(ApplicationDbContext context)
    {
        if (await context.Students.AnyAsync())
            return;

        var students = StudentSeed.Students();

        context.Students.AddRange(students);
        await context.SaveChangesAsync();
    }

    private static async Task SeedCoursesAsync(ApplicationDbContext context)
    {
        if (await context.Courses.AnyAsync())
            return;

        var student = await context.Students.FirstAsync();
        var courses = CourseSeed.Courses();

        foreach (var course in courses)
        {
            course.StudentId = student.Id; // 🔥 HUBUNGKAN FK
        }

        context.Courses.AddRange(courses);
        await context.SaveChangesAsync();
    }
}
