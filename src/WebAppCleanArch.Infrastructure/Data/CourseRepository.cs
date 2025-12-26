using Microsoft.EntityFrameworkCore;
using WebAppCleanArch.Domain.Entities;
using WebAppCleanArch.Domain.Interfaces;
using WebAppCleanArch.Infrastructure.Persistence.Context;

namespace WebAppCleanArch.Infrastructure.Data;
public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _context;

    public CourseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Course>> GetAllAsync()
    {
        return await _context.Courses.ToListAsync();
    }
    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _context.Courses.FindAsync(id);
    }
    public async Task AddAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Courses.AnyAsync(c => c.Id == id);
    }

    public Task<Course> GetCoursesByStudentIdAsync(int studentId)
    {
        throw new NotImplementedException();
    }
}