using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Date;
using Microsoft.AspNetCore.Identity;
using RestReservWebApp.Utility;
using BusinessLogicLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RestReservDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<RestReservDbContext>();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
    //.AddEntityFrameworkStores<RestReservDbContext>();
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
app.UseAuthentication();    

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
