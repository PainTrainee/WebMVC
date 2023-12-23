global using P08_Authorization2.Areas.Identity.Data;
global using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using P08_Authorization2.Data;
using P08_Authorization2.Services;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Authorization2ContextConnection") ?? throw new InvalidOperationException("Connection string 'Authorization2ContextConnection' not found.");

builder.Services.AddDbContext<Authorization2Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MyUser>(options => 
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;

}).AddRoles<IdentityRole>()
.AddEntityFrameworkStores<Authorization2Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRoleService, RoleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
