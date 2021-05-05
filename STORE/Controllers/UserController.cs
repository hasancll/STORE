using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STORE.ENTITY.Entities;
using STORE.ResourceViewModel;
using STORE.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    //ActionFilter sor bakam 

    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetUser()
        {
            StoreUser user = await userService.GetUserByUserName(User.Identity.Name);

            return Ok(user);// Burada mesela adapt ile mapliyor 
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserViewModelResource user)
        {
            var response = await userService.UpdateUser(user, User.Identity.Name);
            return null;
            //if (response.success)
            //{
            //    return Ok(response.extra);
            //}
            //else 
            //{
            //    return BadRequest(response.message);
            //}
        }
        
    }
}
