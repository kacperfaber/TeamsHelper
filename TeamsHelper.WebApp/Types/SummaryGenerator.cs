namespace TeamsHelper.WebApp
{
    public class SummaryGenerator : ISummaryGenerator
    {
        public string Generate(string subject)
        {
            return $"Lekcja: {subject}";
        }
    }
}