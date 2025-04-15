using LibrarySystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register DbContext with SQLite
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite("Data Source=library.db"));

// ✅ Add Session support
builder.Services.AddSession();

// ✅ Register HttpContextAccessor for accessing session in Razor views/layout
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// ✅ SEED DATABASE HERE
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    db.Database.Migrate(); // Ensure database & tables are created
    DataSeeder.SeedDatabase(db); // Seed with data if needed
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // ✅ Enable session before authorization

app.UseAuthorization();

app.MapRazorPages();

// ✅ Optional: fallback to login if route not found
app.MapFallbackToPage("/Auth/Login");

app.Run();
