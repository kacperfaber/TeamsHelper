using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamsHelper.Database
{
    public class Day
    {
        [Key]
        public string Id { get; set; }

        public User Owner { get; set; }

        [InverseProperty("Day")]
        public List<Event> Events { get; set; }
    }
}