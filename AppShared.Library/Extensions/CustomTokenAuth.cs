using AppShared.Library.Configuration;
using AppShared.Library.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShared.Library.Extensions
{
    public static class CustomTokenAuth
    {
        public static void AddCustomTokenAuth(this IServiceCollection services, CustomTokenOption tokenOptions)
        {
            #region Authentication Mekanizm
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience[0],
                    IssuerSigningKey = SignService.GetSymetricSecurityKey(tokenOptions.SecurityKey),

                    //İmzasını dogruluyoruz.
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    //Token'a ömur verdiğimizde  default olarak 5 dk daha ekler
                    //5dk yı farklı zaman aralıklarındakı serverlara kurabılırsın
                    //bunu zero olarak verdiğimizde 5 dk lık sureyı 0'a 0 olarak tanımlıyoruz.
                    ClockSkew = TimeSpan.Zero
                };
            });
            #endregion
        }
    }
}
