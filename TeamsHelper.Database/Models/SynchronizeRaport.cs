using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamsHelper.Database
{
    public class SynchronizeRaport
    {
        [Key]
        public string Id { get; set; }

        public User User { get; set; }

        public DateTime Date { get; set; }

        [InverseProperty("SynchronizeRaport")]
        public List<Meet> Meets { get; set; }
    }
}