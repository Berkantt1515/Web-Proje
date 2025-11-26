
using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; }

        [Display(Name = "Uzmanlık Alanı")]
        public string UzmanlikAlani { get; set; } // [cite: 16]

        // Hangi salonda çalışıyor
        public int GymId { get; set; }
        public virtual Gym? Gym { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }
    }
}
