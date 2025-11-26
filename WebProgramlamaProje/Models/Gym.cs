
using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class Gym
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Salon adı zorunludur.")]
        [Display(Name = "Salon Adı")]
        public string Ad { get; set; }

        [Display(Name = "Adres")]
        public string? Adres { get; set; }

        [Display(Name = "Açılış Saati")]
        public string CalismaSaatiBaslangic { get; set; } // Örn: "09:00" 

        [Display(Name = "Kapanış Saati")]
        public string CalismaSaatiBitis { get; set; }   // Örn: "22:00"

        // İlişkiler
        public virtual ICollection<Trainer>? Trainers { get; set; }
        public virtual ICollection<Service>? Services { get; set; }
    }
}
