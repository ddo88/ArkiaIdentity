using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ArkiaIdentity.Web.Startup
{
    public static class AuthConfigurer
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            if (bool.Parse(configuration["Authentication:JwtBearer:IsEnabled"]))
            {
                services//.AddAuthentication(options=> { options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; })
                    .AddAuthentication()
                    .AddIdentityServerAuthentication("IdentityBearer", options =>
                    {
                        options.Authority = "http://localhost:5000/";
                        options.RequireHttpsMetadata = false;
                    })
                    //.AddOpenIdConnect(options => {
                        
                    //});
                    .AddJwtBearer(options =>
                    {
                        options.Audience = configuration["Authentication:JwtBearer:Audience"];
                        
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // The signing key must match!
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:JwtBearer:SecurityKey"])),

                            // Validate the JWT Issuer (iss) claim
                            ValidateIssuer = true,
                            ValidIssuer = configuration["Authentication:JwtBearer:Issuer"],

                            // Validate the JWT Audience (aud) claim
                            ValidateAudience = true,
                            ValidAudience = configuration["Authentication:JwtBearer:Audience"],

                            // Validate the token expiry
                            ValidateLifetime = true,

                            // If you want to allow a certain amount of clock drift, set that here
                            ClockSkew = TimeSpan.Zero
                        };
                    });
                
            }
        }
    }
}
