

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SurveyApp.DomainClass.Entities;
using SurveyApp.Infrastucture;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public class JwtService : IScopedDependency, IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<Users> signInManager;

        public JwtService(IOptionsSnapshot<JwtSettings> jwtSettings, SignInManager<Users> signInManager)
        {
            _jwtSettings = jwtSettings.Value;

            this.signInManager = signInManager;
        }

        public async Task<AccessToken> GenerateAsync(Users user)
        {
            var secretKey = Encoding.UTF8.GetBytes("LongerThan-16Char-SecretKey"); // longer that 16 character
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var encryptionkey = Encoding.UTF8.GetBytes("16CharEncryptKey"); //must be 16 character
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var claims = await _getClaimsAsync(user);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = "MyWebsite",
                Audience = "MyWebsite",
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(0),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials,
                Subject = new ClaimsIdentity(claims)
            };

            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            //JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
            //JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateJwtSecurityToken(descriptor);

            return new AccessToken(securityToken);
        }

        private async Task<IEnumerable<Claim>> _getClaimsAsync(Users user)
        {
            var result = await signInManager.ClaimsFactory.CreateAsync(user);
            //   add custom claims
            var securityStampClaimType = new ClaimsIdentityOptions().SecurityStampClaimType;

            var list = new List<Claim>{
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FName),
            new Claim(securityStampClaimType, user.SecurityStamp.ToString())
             };

            var roles = new Roles[] { new Roles { Name = "Admin" } };
            foreach (var role in roles)
                list.Add(new Claim(ClaimTypes.Role, role.Name));
             
            return list;
        }
    }
}