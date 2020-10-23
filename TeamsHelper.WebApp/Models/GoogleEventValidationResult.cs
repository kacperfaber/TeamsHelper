namespace TeamsHelper.WebApp
{
    public class GoogleEventValidationResult
    {
        public bool Validated => EndingAtValidated && StartingAtValidated;

        public bool EndingAtValidated { get; set; }

        public bool StartingAtValidated { get; set; }
    }
}