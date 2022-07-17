using Microsoft.EntityFrameworkCore;
using OnlineShop;
using OnlineShop.DataAccess;
using OnlineShop.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DatabaseContext")
	?? throw new InvalidOperationException("Connection string 'DatabaseContext' not found.");

builder.Services.AddDbContext<DatabaseContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services
	.AddDefaultIdentity<SiteUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<DatabaseContext>();

builder.Services.AddInfrastructure();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();