﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class TokenRefresher : ITokenRefresher
    {
        public IFormUrlGenerator FormUrlGenerator;
        public IJsonDeserializer JsonDeserializer;
        public IHttpClient Http;
        

        public TokenRefresher(IFormUrlGenerator formUrlGenerator, IJsonDeserializer jsonDeserializer, IHttpClient http)
        {
            FormUrlGenerator = formUrlGenerator;
            JsonDeserializer = jsonDeserializer;
            Http = http;
        }

        public async Task<Token> RefreshAsync(Authorization authorization, OAuthConfiguration configuration)
        {
            HttpRequestMessage req = new HttpRequestMessage()
            {
                Content = await FormUrlGenerator.GenerateAsync("refresh_token", authorization.RenewToken, "refresh_token", configuration.RedirectUrl,
                    configuration.ClientId, configuration.ClientSecret),
                Method = HttpMethod.Post,
                RequestUri = new Uri(configuration.TokenEndpoint)
            };

            string content = await (await Http.SendAsync(req)).Content.ReadAsStringAsync();

            return JsonDeserializer.Deserialize<Token>(content);
        }
    }
}