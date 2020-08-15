using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JogaFacil.App.Auth
{
    public class FirstAuthStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity(new List<Claim> { 
                new Claim(ClaimTypes.Name, "Pedro")
            }, "auth");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }
    }
}
