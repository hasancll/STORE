using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace STORE.Security.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly CustomTokenOptions customTokenOptions;

        public TokenHandler(IOptions<CustomTokenOptions> customTokenOptions)
        {
            this.customTokenOptions = customTokenOptions.Value;
        }
        public AccessToken CreateAccessToken(StoreUser storeUser)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(customTokenOptions.AccessTokenExpiration);

            var securityKey = SignHandler.GetSecurityKey(customTokenOptions.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: customTokenOptions.Issuer,
                audience: customTokenOptions.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: GetClaim(storeUser),
                signingCredentials: signingCredentials
                );

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            AccessToken accessToken = new AccessToken();

            accessToken.Token = token;
            accessToken.RefreshToken = CreateRefreshToken();
            accessToken.Expiration = accessTokenExpiration;

            return accessToken;
         }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];

            using (var mg = RandomNumberGenerator.Create())
            {
                mg.GetBytes(numberByte);

                return Convert.ToBase64String(numberByte);
            }
        }

        private IEnumerable<Claim> GetClaim(StoreUser storeUser)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,storeUser.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,storeUser.Email),
                new Claim(ClaimTypes.Name,$"{storeUser.UserName}"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            return claims;
        }

        public void RevokeRefreshToken(StoreUser storeUser)
        {
            throw new NotImplementedException();
        }
        
    }
}
