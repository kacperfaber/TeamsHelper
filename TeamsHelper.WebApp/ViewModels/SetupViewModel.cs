﻿using System.Net;

namespace TeamsHelper.WebApp
{
    public class SetupViewModel : ViewModel
    {
        public Authorization MicrosoftAuthorization { get; set; }
        public Authorization GoogleAuthorization { get; set; }
    }
}