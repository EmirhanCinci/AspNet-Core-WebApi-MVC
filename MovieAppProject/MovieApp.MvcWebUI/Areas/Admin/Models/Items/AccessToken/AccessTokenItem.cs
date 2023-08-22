namespace MovieApp.MvcWebUI.Areas.Admin.Models.Items.AccessToken
{
    public class AccessTokenItem
    {
        public List<string> Claims { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
