using AccountService.Dao;
using AccountService.Models.EF;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AccountService.Provider
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            PlayerDao playerDao = new PlayerDao();

            Player player = playerDao.findPlayerByUserName(context.UserName);

            //Dummy check here, you need to do your DB checks against membership system http://bit.ly/SPAAuthCode
            if (player.username == null)
            {
                context.SetError("invalid_grant", "The user name is incorrect");
                //return;
                return Task.FromResult<object>(null);
            }

            if(player.password != MD5.MD5Hash(context.Password))
            {
                context.SetError("invalid_grant", "The password is incorrect");
                //return;
                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity("JWT");

            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("id", player.id));

            identity.AddClaim(new Claim(ClaimTypes.Role, "ROLE_USER"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "ROLE_BASIC"));

            if (player.username == "admin")
            identity.AddClaim(new Claim(ClaimTypes.Role, "ROLE_ADMIN"));
            

            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                         "audience", (context.ClientId == null) ? string.Empty : context.ClientId
                    }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }
    }
}