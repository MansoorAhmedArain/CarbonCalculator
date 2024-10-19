using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WTechAuth.Areas.Identity.Data;
using WTechAuth.Data;

var builder = WebApplication.CreateBuilder(args);

// Connection string configuration
var connectionString = builder.Configuration.GetConnectionString("WTechAuthDbContextConnection")
                     ?? throw new InvalidOperationException("Connection string 'WTechAuthDbContextConnection' not found.");

// Add database context
builder.Services.AddDbContext<WTechAuthDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add session and caching services
builder.Services.AddDistributedMemoryCache(); // Enables in-memory cache for storing session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout period
    options.Cookie.HttpOnly = true; // Cookie accessible only via HTTP (not JS)
    options.Cookie.IsEssential = true; // Ensure the session cookie is always sent
});

// Add identity services
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<WTechAuthDbContext>();

// Add MVC and Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configure Identity options
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Make sure session is enabled before authorization
app.UseAuthentication(); // Add this to ensure authentication middleware is called
app.UseAuthorization();

// Map default controller routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Razor Pages routes
app.MapRazorPages();

app.Run();
