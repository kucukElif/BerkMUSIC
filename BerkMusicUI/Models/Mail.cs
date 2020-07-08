using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BerkMusicUI.Models
{
    public class Mail
    {
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mail adresi boş geçilemez.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Konu giriniz.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj boş geçilemez.")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Telefon numaranızı giriniz.")]
        public string PhoneNumber { get; set; }
    }
}
