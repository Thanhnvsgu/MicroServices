using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using AccountService;
using AccountService.Provider;

[assembly: OwinStartup(typeof(AccountService.Startup))]

namespace AccountService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var issuer = "http://jwtauthzsrv.azurewebsites.net";
            //var audience = "099153c2625149bc8ecb3e85e03f0022";
            //var secret = TextEncodings.Base64Url.Decode("IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw");

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            ConfigureOAuth(app);

            var myProvider = new MyAuthorizationServerProvider();

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = myProvider,
                AccessTokenFormat = new CustomJwtFormat("http://localhost")
            };

            app.UseOAuthAuthorizationServer(options);

            // app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            //Api controllers with an[Authorize] attribute will be validated with JWT
            //app.UseJwtBearerAuthentication(
            //    new JwtBearerAuthenticationOptions
            //    {
            //        AuthenticationMode = AuthenticationMode.Active,
            //        AllowedAudiences = new[] { audience },
            //        IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
            //        {
            //            new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
            //        },
            //        Provider = new OAuthBearerAuthenticationProvider
            //        {
            //            OnValidateIdentity = context =>
            //            {
            //                context.Ticket.Identity.AddClaim(new System.Security.Claims.Claim("newCustomClaim", "newValue"));
            //                return Task.FromResult<object>(null);
            //            }
            //        }
            //    });

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
        public void ConfigureOAuth(IAppBuilder app)
        {
            var issuer = "http://localhost";
            var audience = "099153c2625149bc8ecb3e85e03f0022";
            var secret = TextEncodings.Base64Url.Decode("IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw");

            // Api controllers with an[Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audience },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                    },
                    Provider = new OAuthBearerAuthenticationProvider
                    {
                        OnValidateIdentity = context =>
                        {
                            context.Ticket.Identity.AddClaim(new System.Security.Claims.Claim("newCustomClaim", "newValue"));
                            return Task.FromResult<object>(null);
                        }
                    }
                });
        }
    }
}
