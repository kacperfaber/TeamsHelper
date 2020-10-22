using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public interface IUserProvider
    {
        Task<User> Provide(string emailAddress);

        Task<User> ProvideAsync(string id);

        Task<User> ProvideAsync(HttpContext httpContext);
    }
}