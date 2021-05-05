
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using STORE.ENTITY.Entities;
using STORE.EXCEPTION;
using STORE.MIDDLEWARE.StoreResponseHelper;
using STORE.ResourceViewModel;
using STORE.Security.Token;
using STORE.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace STORE.Services.Concrate
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private readonly ITokenHandler tokenHandler;
        private readonly CustomTokenOptions customTokenOptions;
        private readonly IUserService userService;
        public AuthenticationService(IUserService userService, ITokenHandler tokenHandler,IOptions<CustomTokenOptions> tokenOptions , UserManager<StoreUser> userManager, SignInManager<StoreUser> signInManager, RoleManager<StoreRole> roleManager) : base(userManager, signInManager, roleManager)
        {
            this.tokenHandler = tokenHandler;
            this.userService = userService;
            this.customTokenOptions = tokenOptions.Value;
        }

        public async Task ChangePassword(ChangePasswordResourceModelView changePasswordResourceModelView)
        {
            StoreUser storeUser =await userManager.FindByEmailAsync(changePasswordResourceModelView.Email).ConfigureAwait(false);

            if (storeUser != null)
            {
                bool exist = userManager.CheckPasswordAsync(storeUser, changePasswordResourceModelView.CurrentPassword).Result;
                if (exist)
                {
                    IdentityResult ıdentityResult =await userManager.ChangePasswordAsync(storeUser, changePasswordResourceModelView.CurrentPassword, changePasswordResourceModelView.NewPassword).ConfigureAwait(false);
                }
            }
        }

        public async Task<AccessToken> CreateAccessTokenByRefreshToken(RefreshTokenViewModelResource refreshTokenViewModelResource)
        {
            var userClaim = await userService.GetUserByRefreshToken(refreshTokenViewModelResource.RefreshToken).ConfigureAwait(false);

            if (userClaim.Item1!=null)
            {
                AccessToken accessToken = tokenHandler.CreateAccessToken(userClaim.Item1);
                Claim refreshTokenClaim = new Claim("refreshToken", accessToken.RefreshToken);
                Claim refreshTokenEndDateClaim = new Claim("refreshTokenEndDate", DateTime.Now.AddMinutes(customTokenOptions.RefreshTokenExpiration).ToString());

                await userManager.ReplaceClaimAsync(userClaim.Item1, userClaim.Item2[0], refreshTokenClaim);
                await userManager.ReplaceClaimAsync(userClaim.Item1, userClaim.Item2[1], refreshTokenEndDateClaim);

                return accessToken;
            }
            else
            {
                return null;
            }
        }

        public async Task ResetPassword(PasswordResetViewModelResource passwordResetViewModelResource)
        {
           
            StoreUser storeUser = userManager.FindByEmailAsync(passwordResetViewModelResource.Email).Result;

            if(storeUser != null)
            {
                var newPassword = GetRandomPassword();
                var token =await userManager.GeneratePasswordResetTokenAsync(storeUser).ConfigureAwait(false);
                var ıdentityResult = await userManager.ResetPasswordAsync(storeUser, token,newPassword).ConfigureAwait(false);
                await userManager.UpdateSecurityStampAsync(storeUser).ConfigureAwait(false);
                MailMessage mailMessage = new MailMessage("hasan.cll.97@icloud.com", storeUser.Email);
                mailMessage.Subject = $"Kullanıcı Şifre Yenileme İşlemi.";
                mailMessage.Body = "www.hasanhüseyincalili.com::Şifremi unuttum." + newPassword;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Credentials = new NetworkCredential("hasan.cll.97@icloud.com", "Osman.sude42");
                smtpClient.Port = 587;
                smtpClient.Host = "@icloud.com";
                smtpClient.EnableSsl = true;
                smtpClient.SendAsync(mailMessage, (object)mailMessage);                        
            }
        }
        private String GetRandomPassword()
        {
            Random random = new Random();
            String password = "";

            for (int i = 0; i < 8; i++)
            {
                if (i < 4)
                {
                    password += random.Next(9).ToString();
                }
                else
                {
                    if (i == 7)
                    {
                        password += (char)random.Next(97, 122);
                    }
                    else
                    {
                        password += (char)random.Next(65, 90);
                    }
                }
            }

            return password;
        }

        public async Task<AccessToken> RevokeRefreshToken(RefreshTokenViewModelResource refreshTokenViewModelResource)
        {
            bool result = await userService.RevokeRefreshToken(refreshTokenViewModelResource.RefreshToken).ConfigureAwait(false);

            if (result)
            {
                return new AccessToken();
            }
            else
            {
                return null;
            }
        }

        public async Task<AccessToken> SignIn(SignInViewModelResource signInViewModelResource)
        {
            StoreUser storeUser = await userManager.FindByNameAsync(signInViewModelResource.Username);

            if (storeUser != null)
            {
                bool isUser = await userManager.CheckPasswordAsync(storeUser, signInViewModelResource.Password);
                if (isUser)
                {
                    AccessToken accessToken = tokenHandler.CreateAccessToken(storeUser);

                    Claim refreshTokenClaim = new Claim("refreshToken", accessToken.RefreshToken);
                    Claim refreshTokenEndDateClaim = new Claim("refreshTokenEndDate", DateTime.Now.AddMinutes(customTokenOptions.RefreshTokenExpiration).ToString());

                    List<Claim> refreshClaimList = userManager.GetClaimsAsync(storeUser).Result.Where(c => c.Type.Contains("refreshToken")).ToList();

                    if (refreshClaimList.Any())
                    {
                        await userManager.ReplaceClaimAsync(storeUser, refreshClaimList[0], refreshTokenClaim);
                        await userManager.ReplaceClaimAsync(storeUser, refreshClaimList[1], refreshTokenEndDateClaim);
                    }
                    else
                    {
                        await userManager.AddClaimsAsync(storeUser, new[] { refreshTokenClaim, refreshTokenEndDateClaim });
                    }
                    return accessToken;
                }
                else throw new StoreApiException("Kullanıcı adı veya parola yanlış.");
            }
            else throw new StoreApiException("Kullanıcı adı veya parola yanlış.");

        }

        public async Task<UserViewModelResource> SignUp(UserViewModelResource userViewModelResource)
        {
            StoreUser storeUser = new StoreUser { UserName = userViewModelResource.Username, Email = userViewModelResource.Email };

            IdentityResult result = await this.userManager.CreateAsync(storeUser, userViewModelResource.Password).ConfigureAwait(false);

            storeUser.Email = userViewModelResource.Email;
            storeUser.UserName = userViewModelResource.Username;
            if(result.Succeeded)
            {
                return userViewModelResource;
            }
            else
            {
                throw new StoreApiException("Kullanıcı oluşturulumadı.");
            }
        }
    }
}
