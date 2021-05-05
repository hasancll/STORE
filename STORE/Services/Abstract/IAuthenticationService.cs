using STORE.ENTITY.Entities;
using STORE.ResourceViewModel;
using STORE.Security.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Services.Abstract
{
    public interface IAuthenticationService
    {
        Task<UserViewModelResource> SignUp(UserViewModelResource userViewModelResource);
        Task<AccessToken> SignIn(SignInViewModelResource signInViewModelResource);
        Task ResetPassword(PasswordResetViewModelResource passwordResetViewModelResource);
        Task ChangePassword(ChangePasswordResourceModelView changePasswordResourceModelView);
        Task<AccessToken> CreateAccessTokenByRefreshToken(RefreshTokenViewModelResource refreshTokenViewModelResource);
        Task<AccessToken> RevokeRefreshToken(RefreshTokenViewModelResource refreshTokenViewModelResource);
    }
}
