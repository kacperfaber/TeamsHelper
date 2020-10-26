using TeamsHelper.Database;
namespace TeamsHelper.WebApp
{
    public class SetupViewModel : ViewModel
    {
        public TokenValidation GoogleValidation { get; set; }
        public TokenValidation MicrosoftValidation { get; set; }
        public Token GoogleToken { get; set; }
        public Token MicrosoftToken { get; set; }
    }
}