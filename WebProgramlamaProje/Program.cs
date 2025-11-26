using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProje.Data;
using WebProgramlamaProje.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Þifre kurallarýný "sau" olabilsin diye basitleþtiriyoruz
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.Password.RequireDigit = false; // Rakam zorunluluðu yok
    options.Password.RequireLowercase = false; // Küçük harf zorunluluðu yok
    options.Password.RequireUppercase = false; // Büyük harf zorunluluðu yok
    options.Password.RequireNonAlphanumeric = false; // Özel karakter (!, @) yok
    options.Password.RequiredLength = 3; // En az 3 karakter (sau için)
})
.AddRoles<IdentityRole>() // Rolleri aktif et
.AddEntityFrameworkStores<ApplicationDbContext>();
    
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

// Uygulama baþlarken Admin hesabýný ekle
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DbSeeder.SeedRolesAndAdminAsync(services);
}
app.Run();
