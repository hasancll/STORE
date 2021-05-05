using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.ResourceViewModel
{
    public class ChangePasswordResourceModelView
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string CurrentPassword { get; set; }
    }
}
