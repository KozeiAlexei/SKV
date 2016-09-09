using System.Security.Claims;

namespace SKV.ML.ViewModels.Account
{
    public class OAuthUserModel
    {
        public ClaimsIdentity OAuthIdentity { get; set; }
        public ClaimsIdentity CookiesIdentity { get; set; }
    }
}
