using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArticleBZ.Client.Services
{
    public class Jwtservice : AuthenticationStateProvider
    {
        IJSRuntime _js;
        public Jwtservice( IJSRuntime js)
        {
            _js = js;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
          

         var token= await  _js.GetItem("Token");
            var user = await _js.GetUser("User");
            if(token == null&& user==null)
            {
                var nobody = new ClaimsIdentity();

                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(nobody)));

            }
            else
            {
                var claims = new List<Claim>
            {
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Name, user.Email),
        new Claim(ClaimTypes.Role, "Administrator")
            };
          
                var identity = new ClaimsIdentity(claims);
              

                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
            }
           
           
    }
        public void Build (AuthenticationState state)
        {
            NotifyAuthenticationStateChanged(Task.FromResult(state));
           
        }


    }
}
