using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using System.Security.AccessControl;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;

namespace homework_1.Models
{
    public class SignInViewModel
    {
        
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Lütfen isim alanını boş bırakmayınız!")]      // Boş geçilmemesinin kontrolünü sağlayan kısım
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Lütfen sadece harf kullanın.")]  // İsim alanının sadece harflerden oluşmasını kontrol eden pattern 
        public string FirstName { get; set; }
         
        
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Lütfen soyad alanını boş bırakmayınız!")]    // Boş geçilmemesinin kontrolünü sağlayan kısım
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Lütfen sadece harf kullanın.")] // Soyisim alanının sadece harflerden oluşmasını kontrol eden pattern
        public string LastName { get; set; }
         
        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Lütfen email alanını boş bırakmayınız!")]     // Boş geçilmemesinin kontrolünü sağlayan kısım    
        [RegularExpression("^[A-Za-z0-9](([_\\.\\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\\.\\-]?[a-zA-Z0-9]+)*)\\.([A-Za-z]{2,})$", ErrorMessage = "Hatalı giriş tekrar deneyin. Örn: asd@fgh.com")] // Geçerli bir e mail girilmesini kontrol edene pattern
       
        public string  Email{ get; set; }
         
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre alanını boş bırakmayınız!")]     // Boş geçilmemesinin kontrolünü sağlayan kısım
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$", ErrorMessage = "Geçersiz giriş. En az 1 büyük harf ve En az bir sayı olmalı!")] //En az 1 sayı ve en az 1 büyük harf olmasını kontrol eden pattern ifadesi
        public string Password { get; set; }
         
    }
}


