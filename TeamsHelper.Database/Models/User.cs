using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamsHelper.Database
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        
        public string EmailAddress { get; set; }
        
        public string Password { get; set; }

        public string DisplayName { get; set; }

        [ForeignKey("GoogleAuthorizationId")]
        public Authorization GoogleAuthorization { get; set; }

        public string GoogleAuthorizationId { get; set; }

        [ForeignKey("MicrosoftAuthorizationId")]
        public Authorization MicrosoftAuthorization { get; set; }
        
        public string MicrosoftAuthorizationId { get; set; }
    }
}