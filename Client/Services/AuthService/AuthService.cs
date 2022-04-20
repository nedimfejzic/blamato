using blamato.Shared;
using blamato.Shared.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace blamato.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public Task<ServiceResponse<bool>> ChangePassword(UserChangePasswordDTO request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _authenticationStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;

        }

        public async Task<ServiceResponse<string>> Login(UserLoginDTO request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/login", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<int>> Register(UserRegister request)
        {
           var result = await _httpClient.PostAsJsonAsync("api/auth/register", request);
           return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>() ;
        }
    }
}
