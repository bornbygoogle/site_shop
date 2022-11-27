using System;

namespace BlazorApp.Shared
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public string ClientSecret { get; set; }

        public string GrantType { get; set; }
    }
}
