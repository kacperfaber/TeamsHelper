using System;
using System.ComponentModel.DataAnnotations;

namespace TeamsHelper.Database
{
    public class Authorization
    {
        [Key]
        public Guid Id { get; set; }
        
        public string AccessToken { get; set; }

        public string RenewToken { get; set; }
    }
}