﻿using System.Threading.Tasks;

namespace TeamsHelper.WebApp
{
    public class GoogleRedirectUrlGenerator : IGoogleRedirectUrlGenerator
    {
        public Task<string> GenerateAsync(OAuthConfiguration authConfiguration, string responseType)
        {
            return Task.Run(() => $"https://accounts.google.com/o/oauth2/v2/auth?redirect_uri={authConfiguration.RedirectUrl}&prompt=consent&scope={authConfiguration.Scopes}&client_id={authConfiguration.ClientId}&response_type={responseType}&access_type=offline&code_challenge={authConfiguration.CodeChallenge}&code_challenge_method={authConfiguration.CodeChallengeMethod}");
        }
    }
}