﻿using System.Net.Http;
using System.Threading.Tasks;

namespace TeamsHelper.TeamsApi
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}