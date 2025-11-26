
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Ad")]
        public string? Ad { get; set; }

        [Display(Name = "Soyad")]
        public string? Soyad { get; set; }

        [Display(Name = "Doğum Tarihi")]
        public DateTime? DogumTarihi { get; set; }

        
        [Display(Name = "Boy (cm)")]
        public int? Boy { get; set; }

        [Display(Name = "Kilo (kg)")]
        public double? Kilo { get; set; }

        [Display(Name = "Cinsiyet")]
        public string? Cinsiyet { get; set; }
    }
}