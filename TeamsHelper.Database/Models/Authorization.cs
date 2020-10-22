using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamsHelper.Database
{
    public class Authorization
    {
        [Key]
        public string Id { get; set; }
        
        public string AccessToken { get; set; }

        public string RenewToken { get; set; }
        
        public DateTime GeneratedAt { get; set; }
    }
}