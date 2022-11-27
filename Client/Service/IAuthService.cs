namespace BlazorApp.Client.Service
{
    public interface IAuthService
    {
        //Task<LoginResult> Login(UserModel user);
        Task Logout();
        //Task<RegisterResult> Register(RegisterModel registerModel);
    }
}
