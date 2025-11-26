using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProje.Models; 

namespace WebProgramlamaProje.Data
{
    // Standart IdentityDbContext yerine IdentityDbContext<ApplicationUser> kullanıyoruz.
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Veritabanında oluşacak tabloları (DbSet) burada tanımlıyoruz
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 1. DECIMAL UYARISINI DÜZELTME
            // Service tablosundaki Ucret alanı için (18 basamak, virgülden sonra 2 hane)
            builder.Entity<Service>()
                .Property(s => s.Ucret)
                .HasColumnType("decimal(18,2)");

            // 2. CASCADE CYCLE HATASINI DÜZELTME
            // Bir antrenör silinirse, geçmiş randevuları silinmesin (Restrict)
            builder.Entity<Appointment>()
                .HasOne(a => a.Antrenor)
                .WithMany(t => t.Appointments)
                .HasForeignKey(a => a.AntrenorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Bir hizmet silinirse, geçmiş randevuları silinmesin (Restrict)
            builder.Entity<Appointment>()
                .HasOne(a => a.Hizmet)
                .WithMany()
                .HasForeignKey(a => a.HizmetId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
