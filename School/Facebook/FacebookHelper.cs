using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace School.Facebook
{
    public class FacebookHelper
    {
        public WebResponse PostOnFacebook(string message)
        {
            const string accessToken = "EAAEmb7dXscoBAKEJ1zzzMRzMoE6lS369wRS6DydpTcJ6QO8NJ4P0arkFlhduKAZA5pH2AR8vkygwjHSbNf8LRokk2JZBwUYPxHSmFewIOitqQd3vUpX6qASnB8JcgQK3p4rBDbISky9cKNeyxudWM1n0V6GTUqDWsxeHbQS59ZBAf78g34p3TxVZAjIul8QSMEIHNjXJZAFbAX05J4I9ZC0oJHu13YlfIZD";
            const string appId = "102606958731750";

            var url = $"https://graph.facebook.com/v11.0/{appId}/feed?message={message}&access_token={accessToken}";

            var httpRequest = WebRequest.Create(url);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/x-www-form-urlencoded";

            return httpRequest.GetResponse();

            /*using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://graph.facebook.com/");

            var parametters = new Dictionary<string, string>
            {
                { "access_token", "EAAEmb7dXscoBAPEal0ZCQBZAIVKoqyrRUFZBZCtcGMYxJsio9w616nDTuMw1yZB34rPmsG4ilqoUCmHye1hqZCPUdqdMw38gOkXRwjryNKIy3zavyYiy6ILTArL6uApaqBe9PDXwtyOiePRNSkhSu77qcHp1jSdALAhSDWleYstgtrkoW9eNDhQxZB9U8BF4QnVwXytloJRqFHPe4tkqFXbh6t0AUV65eYZD" },
                { "message", message }
            };
            var encodedContent = new FormUrlEncodedContent(parametters);

            var result = await httpClient.PostAsync($"{102606958731750}/feed", encodedContent);
            var msg = result.EnsureSuccessStatusCode();
            return await msg.Content.ReadAsStringAsync();*/
        }
    }
}
