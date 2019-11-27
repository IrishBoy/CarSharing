using CarSharing.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSharing.Core.Models
{
    public class Session
    {
        public User User { get; set; }
        public Car Car { get; set; }

        public DateTime StartDt { get; set; }
        public DateTime? EndDt { get; set; }

        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }

        public decimal? TotalCost { get; set; }
    }
}
