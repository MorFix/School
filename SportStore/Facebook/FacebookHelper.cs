using System.Net;

namespace SportStore.Facebook
{
    public class FacebookHelper
    {
        public WebResponse PostOnFacebook(string message)
        {
            const string accessToken = "accessToken";
            const string appId = "appId";

            var url = $"https://graph.facebook.com/{appId}/feed?message={message}&access_token={accessToken}";

            var httpRequest = WebRequest.Create(url);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/x-www-form-urlencoded";

            return httpRequest.GetResponse();
        }
    }
}
