using Microsoft.AspNetCore.Identity;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            // Kullanıcı ve Rol yöneticilerini servisten alıyoruz
            var userManager = service.GetService<UserManager<ApplicationUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();

            // 1. ROLLERİ OLUŞTUR (Admin ve Member)
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("Member"));

            // 2. ADMİN KULLANCISINI OLUŞTUR
            
            var adminEmail = "G221210040@sakarya.edu.tr"; 
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Ad = "Admin",
                    Soyad = "Yonetici",
                    EmailConfirmed = true,
                    Cinsiyet = "Belirtilmemiş"
                };

               
                
                var result = await userManager.CreateAsync(adminUser, "sau");

                if (result.Succeeded)
                {
                    // Kullanıcıya Admin rolünü ata
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}