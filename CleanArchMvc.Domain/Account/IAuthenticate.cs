namespace CleanArchMvc.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> RegistrateUser(string email, string password);
        Task Logout();

    }
}