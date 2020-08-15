using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JogaFacil.App.Helpers;
using System.Security.Claims;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace JogaFacil.App.Auth
{
    public class JWTAuthProvider : AuthenticationStateProvider, ILoginService
    {
        private readonly IJSRuntime _js;
        private readonly HttpClient _httpClient;
        private static readonly string TOKENKEY = "TOKENKEY";
        private AuthenticationState Anonymous => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        public JWTAuthProvider(IJSRuntime js, HttpClient httpClient)
        {
            _js = js;
            _httpClient = httpClient;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _js.GetFromLocalStorage(TOKENKEY);

            if (string.IsNullOrEmpty(token))
                return Anonymous;

            return BuildAuthenticationState(token);
        }

        public async Task Login(string token)
        {
            await _js.SetInLocalStorage(TOKENKEY, token);
            var authState = BuildAuthenticationState(token);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task Logout()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            await _js.RemoveItem(TOKENKEY);
            NotifyAuthenticationStateChanged(Task.FromResult(Anonymous));
        }

        private AuthenticationState BuildAuthenticationState(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
