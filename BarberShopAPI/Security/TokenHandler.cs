using System;
using BarberShopAPI.Models.Dto;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace BarberShopAPI.Security
{
    public class TokenHandler
    {
        private const string Secret = "3d6f094feb7e43d4ab34c2350ee87506";

        public static string GenerateToken(string dataStructure, int expireMinutes = 262800)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "Login"),
                    new Claim("Data", dataStructure)
                }),
                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),
                Issuer = "TuBS",
                Audience = "New Login",
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);
            tokenHandler.ReadJwtToken(token);
            return token;
        }

        public static string DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            ValidateToken(token);

            var parsedToken = tokenHandler.ReadJwtToken(token);

            List<Claim> data = (List<Claim>)parsedToken.Claims;

            return data.Find(d => d.Type.Equals("Data", StringComparison.CurrentCultureIgnoreCase)).Value;
        }

        /// <summary>
        /// Validates the token and raises Exception if invalid.
        /// </summary>
        /// <param name="authToken">Token to validate</param>
        private static void ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            _ = tokenHandler.ValidateToken(authToken, validationParameters, out SecurityToken validatedToken);
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true, // Because there is no expiration in the generated token
                ValidateAudience = true, // Because there is no audiance in the generated token
                ValidateIssuer = true,   // Because there is no issuer in the generated token
                ValidIssuer = "TuBS",
                ValidAudience = "New Login",
                IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(Secret)) // The same key as the one that generate the token
            };
        }
    }
}