
using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Randevu Tarihi ve Saati")]
        public DateTime TarihSaat { get; set; }

        // İlişkiler
        [Display(Name = "Üye")]
        public string UyeId { get; set; }
        public virtual ApplicationUser? Uye { get; set; }

        [Display(Name = "Antrenör")]
        public int AntrenorId { get; set; }
        public virtual Trainer? Antrenor { get; set; }

        [Display(Name = "Hizmet")]
        public int HizmetId { get; set; }
        public virtual Service? Hizmet { get; set; } // [cite: 20]

        [Display(Name = "Durum")]
        public string Durum { get; set; } = "Bekliyor"; // Onay mekanizması için [cite: 21]
    }
}