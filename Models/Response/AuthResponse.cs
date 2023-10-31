namespace RedeSocialAPI.Models.Response
{
    public class AuthResponse
    {
        public string? Access_Token { get; set; }
        public int? expires_in { get; set; }
        public string? Token_Type { get; set; }
    }
}
