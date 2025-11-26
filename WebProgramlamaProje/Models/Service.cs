
using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Hizmet Adı")]
        public string Ad { get; set; }

        [Display(Name = "Süre (Dakika)")]
        public int SureDk { get; set; } // 

        [Display(Name = "Ücret (TL)")]
        public decimal Ucret { get; set; } // 

        // Hangi salona ait olduğu
        public int GymId { get; set; }
        public virtual Gym? Gym { get; set; }
    }
}