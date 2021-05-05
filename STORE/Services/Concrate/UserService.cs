using Microsoft.AspNetCore.Identity;
using STORE.ENTITY.Entities;
using STORE.EXCEPTION;
using STORE.ResourceViewModel;
using STORE.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace STORE.Services.Concrate
{
    public class UserService : BaseService, IUserService
    {
        public UserService(UserManager<StoreUser> userManager,SignInManager<StoreUser> signInManager,RoleManager<StoreRole> roleManager):base(userManager,signInManager,roleManager)
        {
            
        }
        public async Task<Tuple<StoreUser, IList<Claim>>> GetUserByRefreshToken(string refreshToken)
        {
            Claim claimRefreshToken = new Claim("refreshToken", refreshToken);

            var users = await userManager.GetUsersForClaimAsync(claimRefreshToken).ConfigureAwait(false);

            if (users.Any())
            {
                var user = users.First();

                IList<Claim> userClaims = await userManager.GetClaimsAsync(user);

                string refreshTokenEndDate = userClaims.First(c => c.Type == "refreshTokenEndDate").Value;
                if (DateTime.Parse(refreshTokenEndDate) > DateTime.Now)
                {
                    return new Tuple<StoreUser, IList<Claim>>(user, userClaims);
                }
                else
                {
                    return new Tuple<StoreUser, IList<Claim>>(null, null);
                }
            }
            return new Tuple<StoreUser, IList<Claim>>(null, null);
        }

        public async Task<StoreUser> GetUserByUserName(string userName)
        {
            return await userManager.FindByNameAsync(userName).ConfigureAwait(false);
        }

        public async Task<bool> RevokeRefreshToken(string refreshToken)
        {
            var result = await GetUserByRefreshToken(refreshToken).ConfigureAwait(false);

            if (result.Item1 == null)
            {
                return false;
            }
            IdentityResult response = await userManager.RemoveClaimsAsync(result.Item1, result.Item2);

            if (response.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<UserViewModelResource> UpdateUser(UserViewModelResource userViewModelResource, string userName)
        {
            StoreUser user = await userManager.FindByNameAsync(userName).ConfigureAwait(false);
            user.Email = userViewModelResource.Email;
            user.UserName = userViewModelResource.Username;

            IdentityResult result = await userManager.UpdateAsync(user).ConfigureAwait(false);

            if (result.Succeeded)
            {
                return userViewModelResource;
            }
            //Burayı sor bakam
            else
            {
                return null;
            }
          

        }
    }
}
