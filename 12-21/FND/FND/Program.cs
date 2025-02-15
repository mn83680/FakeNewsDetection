using FND.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Entity>(optionBuilder => {
    optionBuilder.UseSqlServer("Data Source=.;Initial Catalog=FND-1;Integrated Security=True");
});
//register usermanager,rolemanager==>userrole
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
              options => options.Password.RequireDigit = true
              ).
              AddEntityFrameworkStores<Entity>();
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
app.UseAuthentication();//requet
app.UseAuthorization();

//open default page
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=News}/{action=AllNews}/{id?}");

app.Run();
