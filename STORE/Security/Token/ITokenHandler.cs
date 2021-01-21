using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Security.Token
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(StoreUser storeUser);

        void RevokeRefreshToken(StoreUser storeUser);
    }
}
