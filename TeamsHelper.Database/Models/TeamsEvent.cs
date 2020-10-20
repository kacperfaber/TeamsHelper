using System;
using System.ComponentModel.DataAnnotations;

namespace TeamsHelper.Database
{
    public class TeamsEvent
    {
        [Key]
        public string EventId { get; set; }
    }
}