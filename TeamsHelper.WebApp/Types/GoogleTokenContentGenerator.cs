﻿using System.Net.Http;
using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class GoogleTokenContentGenerator : IGoogleTokenContentGenerator
    {
        public IFormUrlGenerator FormUrlGenerator;

        public GoogleTokenContentGenerator(IFormUrlGenerator formUrlGenerator)
        {
            FormUrlGenerator = formUrlGenerator;
        }

        public Task<FormUrlEncodedContent> GenerateAsync(string code, OAuthConfiguration configuration)
        {
            return FormUrlGenerator.GenerateAsync("code", code, "authorization_code", configuration.RedirectUrl, configuration.ClientId,
                configuration.ClientSecret);
        }
    }
}