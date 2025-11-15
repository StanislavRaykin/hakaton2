using hakaton2.dataAccess.Entities;
using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using hakaton2.dataAccess;
using hakaton2.dataAccess.interf;
using hakaton2.dataAccess.dataAccess;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserManager, UserDataAccess>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddDbContext<hakatonContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("hakatonContext")));

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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
