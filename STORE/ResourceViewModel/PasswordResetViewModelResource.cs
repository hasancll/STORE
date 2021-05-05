using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.ResourceViewModel
{
    public class PasswordResetViewModelResource
    {
        [Required(ErrorMessage = "Email  alanı boş bırakılamaz")]
        //[EmailAddress]
        public string Email { get; set; }

    }
}
