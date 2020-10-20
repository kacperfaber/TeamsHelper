using System;
using System.ComponentModel.DataAnnotations;

namespace TeamsHelper.Database
{
    public class GoogleEvent
    {
        [Key]
        public string EventId { get; set; }
    }
}