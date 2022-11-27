using BlazorApp.Shared;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BlazorApp.Client.Service
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        //public async Task<RegisterResult> Register(RegisterModel registerModel)
        //{
        //    var resultMessage = await _httpClient.PostAsJsonAsync<RegisterModel>("api/accounts", registerModel);

        //    var result = JsonSerializer.Deserialize<RegisterResult>(await resultMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        //    return result;
        //}

        //public async Task<LoginResult> Login(User user)
        //{
        //    LoginResult loginResult = new LoginResult();

        //    if (user == null || (user != null && (user.UserName == null || user.Password == null)))
        //    {
        //        loginResult.Successful = false;
        //        loginResult.Error = "Missing credentials !";
        //        return loginResult;
        //    }

        //    var response = await _httpClient.PostAsync("https://blazorlifemusic-server.herokuapp.com/login/login", new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json"));

        //    if (response == null || (response != null && response.Content == null))
        //    {
        //        loginResult.Successful = false;
        //        loginResult.Error = "Error credentials !";
        //        return loginResult;
        //    }

        //    var sResponse = await response.Content.ReadAsStringAsync();

        //    if (string.IsNullOrEmpty(sResponse))
        //    {
        //        loginResult.Successful = false;
        //        loginResult.Error = "Error credentials !";
        //        return loginResult;
        //    }

        //    var oResponse = JsonSerializer.Deserialize<Token>(sResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        //    if (oResponse == null || oResponse.GetType().GetProperties().Any(prop => prop == null))
        //    {
        //        loginResult.Successful = false;
        //        loginResult.Error = "Erreur response from server !";
        //        return loginResult;
        //    }

        //    loginResult.Successful = true;
        //    loginResult.Token = oResponse;

        //    await _localStorage.SetItemAsync("authToken", loginResult.Token.AccessToken);

        //    ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(user.UserName);
        //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token.AccessToken);

        //    return loginResult;
        //}

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
