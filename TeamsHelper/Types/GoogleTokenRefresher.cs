﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeamsHelper
{
    public class GoogleTokenRefresher : IGoogleTokenRefresher
    {
        readonly HttpClient _http = new HttpClient();
        
        public IFormUrlEncodedContentGenerator FormUrlEncodedContentGenerator;

        public GoogleTokenRefresher(IFormUrlEncodedContentGenerator formUrlEncodedContentGenerator)
        {
            FormUrlEncodedContentGenerator = formUrlEncodedContentGenerator;
        }

        public async Task<string> RefreshAsync(string refreshToken, ClientCredentials credentials)
        {
            const string url = "https://login.microsoftonline.com/466d5c5a-54d4-45fc-98eb-7877acf57f5f/oauth2/v2.0/token";

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = FormUrlEncodedContentGenerator.Generate(refreshToken, credentials),
                Method = HttpMethod.Post,
                RequestUri = new Uri(url)
            };

            string content = await (await _http.SendAsync(request)).Content.ReadAsStringAsync();
            return JObject.Parse(content)["access_token"].ToObject<string>();
        }
    }
}