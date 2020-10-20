﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamsHelper.Database
{
    public class User
    {
        public Guid Id { get; set; }
        
        public string EmailAddress { get; set; }
        
        public string Password { get; set; }

        [ForeignKey("MicrosoftAuthorizationId")]
        public Authorization MicrosoftAuthorization { get; set; }
        
        [ForeignKey("GoogleAuthorizationId")]
        public Authorization GoogleAuthorization { get; set; }
    }
}