using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.ResourceViewModel
{
    public class UserViewModelResource
    {
        [Required(ErrorMessage ="Kullanıcı ismi gereklidir.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre girilmesi gereklidir.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password girilmesi gereklidir")]
        public string Password { get; set; }

    }
}
