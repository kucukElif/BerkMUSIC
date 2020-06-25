using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BerkMusicUI.Areas.Admin.Models.ViewModels
{
    public class AppUserVM
    {
        [Required(ErrorMessage = "Kullanıcı adı boş olamaz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre boş olamaz.")]
        public string Password { get; set; }
    }
}
