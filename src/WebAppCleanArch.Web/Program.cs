using WebAppCleanArch.Application.Students;
using WebAppCleanArch.Domain.Interfaces;
using WebAppCleanArch.Application.Courses;
using WebAppCleanArch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WebAppCleanArch.Infrastructure.Persistence.Context;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
