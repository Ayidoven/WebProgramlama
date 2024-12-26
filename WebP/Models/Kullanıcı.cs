using System.ComponentModel.DataAnnotations;

namespace WebP.Models
{
    public class Kullanıcı
    {
        [Key]
        public int KullanıcıId { get; set; }

        [Required(ErrorMessage = "Ad Soyad gerekli.")]
        [StringLength(100)]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "E-posta gerekli.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gerekli.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
    }
}