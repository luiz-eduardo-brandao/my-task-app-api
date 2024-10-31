namespace MyTaskApp.Core.DTOs
{
    public class TokenDTO
    {
        public TokenDTO(string token, string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
