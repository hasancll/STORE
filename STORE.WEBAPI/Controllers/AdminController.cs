using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using STORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEBAPI.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<StoreApiUser> UserManager{get;}
        public AdminController(UserManager<StoreApiUser> userManager)
        {
            this.UserManager = userManager;
        }
        public IActionResult Index()
        {
            return View(UserManager.Users.ToList());
        }
    }
}
