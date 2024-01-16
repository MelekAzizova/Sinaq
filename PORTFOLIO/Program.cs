using Microsoft.EntityFrameworkCore;
using PORTFOLIO.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TempDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Detal}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//   PathConstants.RootPath = builder.Environment.WebRootPath;

app.Run();
