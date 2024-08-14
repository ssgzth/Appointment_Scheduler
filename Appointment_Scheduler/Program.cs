using Appointment_Scheduler.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAppointment, SQLAppointmentRepo>();
builder.Services.AddDbContextPool<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration["ConnectionStrings:AppointmentDbConnection"]));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(
    option =>
    {
        option.Password.RequiredLength = 10;
        option.Password.RequiredUniqueChars = 3;
        
    }
    ).AddEntityFrameworkStores<AppDbContext>();

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
