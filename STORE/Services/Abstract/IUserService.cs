using STORE.ENTITY.Entities;
using STORE.ResourceViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace STORE.Services.Abstract
{
    public interface IUserService
    {
        Task<UserViewModelResource> UpdateUser(UserViewModelResource userViewModelResource, string userName);
        Task<StoreUser> GetUserByUserName(string userName);
        Task<Tuple<StoreUser, IList<Claim>>> GetUserByRefreshToken(string refreshToken);
        Task<bool> RevokeRefreshToken(string refreshToken);

    }
}
