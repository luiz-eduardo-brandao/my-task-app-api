namespace MyTaskApp.Application.InputModels
{
    public class VerifyTokenInputModel
    {
        public int IdUser { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
