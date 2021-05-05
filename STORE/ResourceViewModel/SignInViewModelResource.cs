using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.ResourceViewModel
{
    public class SignInViewModelResource
    {
        [Required(ErrorMessage ="Kullanıcı adı girilmesi zorunludur")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Şifre girimesi zorunludur")]
        [MinLength(4,ErrorMessage ="Şifreniz en az 4 karakterli olmak zorundadır.")]
        public string Password { get; set; }
    }
}
