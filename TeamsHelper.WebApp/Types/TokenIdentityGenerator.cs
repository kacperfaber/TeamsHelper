using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TeamsHelper.WebApp
{
    public class TokenIdentityGenerator : ITokenIdentityGenerator
    {
        public Task<Identity> GenerateAsync(OAuthConfiguration authConfiguration, string content)
        {
            return Task.Run(() =>
            {
                JObject obj = JObject.Parse(content);

                Identity identity = new Identity
                {
                    Email = obj.SelectToken(authConfiguration.IdentityModel.Email).ToObject<string>(),
                    Id = obj.SelectToken(authConfiguration.IdentityModel.Id).ToObject<string>(),
                    Name = obj.SelectToken(authConfiguration.IdentityModel.Name).ToObject<string>(),
                };

                return identity;
            });
        }
    }
}