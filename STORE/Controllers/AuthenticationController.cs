using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly UserManager<StoreUser> userManager;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        [HttpGet]
        [Authorize]
        public ActionResult IsAuthentication()
        {
            return Ok(User.Identity.IsAuthenticated);
        }
        //[Authorize]
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserViewModelResource userViewModelResource)
        {
           UserViewModelResource response= await this.authenticationService.SignUp(userViewModelResource);

            return Ok(response);

        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody]SignInViewModelResource signInViewModelResource)
        {
            var response = await authenticationService.SignIn(signInViewModelResource).ConfigureAwait(false);
            return Ok(response);
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(PasswordResetViewModelResource passwordResetViewModelResource)
        {
            await authenticationService.ResetPassword(passwordResetViewModelResource).ConfigureAwait(false);

            return Ok(passwordResetViewModelResource);

        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordResourceModelView changePasswordResourceModelView)
        {
            await authenticationService.ChangePassword(changePasswordResourceModelView).ConfigureAwait(false);
            return Ok();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> TokenByRefreshToken(RefreshTokenViewModelResource refreshTokenViewModelResource)
        {
            return null;
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenViewModelResource refreshTokenViewModelResource)
        {

            return null;
            //var response = await authenticationService.RevokeRefreshToken(refreshTokenViewModelResource).ConfigureAwait(false);
            //if (response.Success)
            //{
            //    return Ok();
            //}
            //else
            //{
            //    return BadRequest(response.Message);
            //}
        }
    }
}
