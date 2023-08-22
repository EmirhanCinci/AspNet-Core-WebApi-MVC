namespace Infrastructure.Utilities.Security
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int TokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
