using UMBRAPage.Data;
using UMBRAPage.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();

string connFile = "/etc/secrets/ConnectionStrings__DefaultConnection";
string connectionString = null;

if (File.Exists(connFile))
{
    connectionString = File.ReadAllText(connFile).Trim();
}
else
{
#if DEBUG
    DotNetEnv.Env.Load(); // Load from .env during development
    connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
#endif
}

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Missing database connection string.");
}


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
    AdminUserSeeder.Seed(db);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
