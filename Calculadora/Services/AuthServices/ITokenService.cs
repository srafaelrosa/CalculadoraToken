namespace Calculadora.Services.AuthServices
{
    public interface ITokenService
    {
        string GenerateAccessToken(string userId);
        DateTime GetAccessTokenExpiration();
    }
}
