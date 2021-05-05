using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Concrate
{
    public class BaseService:ControllerBase
    {
        protected UserManager<StoreUser> userManager { get; }
        protected SignInManager<StoreUser> signInManager { get; }
        protected RoleManager<StoreRole> roleManager { get; }
        public BaseService(UserManager<StoreUser> userManager,SignInManager<StoreUser> signInManager,RoleManager<StoreRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
    }
}
