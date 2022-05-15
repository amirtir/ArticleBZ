using ArticleBZ.Client.Repositories;
using ArticleBZ.Shared.DTOs;
using ArticleBZ.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;


namespace ArticleBZ.Client.Services
{


    public class UserServices :   IUserService
    {
       private HttpClient _client;
        private IJSRuntime _js;
        
        public UserServices( HttpClient client , IJSRuntime js)
        {
       _client = client;
            _js = js;
          
        }

     

        public async Task<User>  CreateUser(UserVM userVM)
        {
            var result = _client.PostAsJsonAsync<UserVM>(_client.BaseAddress + "api/User", userVM).Result.Content.ReadFromJsonAsync<User>() ;
            
            //var final =  JsonConvert.DeserializeObject<User>( result);
            return await result;    
        }

       

        public async Task<List<User>> GetUsers()
        {
            var result = _client.GetFromJsonAsync<List<User>>(_client.BaseAddress + "api/User");
          //var final=  JsonConvert.DeserializeObject<List<User>>(await result);
            return await result;
        }

        public async Task<Token>   LoginUser(LoginVM loginVM)
        {
            var result = await _client.PostAsJsonAsync<LoginVM>("https://localhost:44376/api/auth/login", loginVM);
            var token = await result.Content.ReadFromJsonAsync<Token>();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.token);
            return  token;


                //{ 
                //    var token= result.Content.ReadFromJsonAsync<Token>().Result;

                //    _js.SetItem("token", token.token);
                //    _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token.token);

                //    // var claims = new List<Claim>() {
                //    //        new Claim(ClaimTypes.NameIdentifier,loginVM.Email),
                //    //        new Claim(ClaimTypes.Name,loginVM.Email),
                //    //        new Claim("AccsessToken",token.token)

                //    //    };

                //    //var identity = new ClaimsIdentity(claims);

                //    //var principal = new ClaimsPrincipal(identity);
                //    //AuthenticationState state = new AuthenticationState(principal);

                //    return  token.token;
                //}

                
        }

  
    }
}
