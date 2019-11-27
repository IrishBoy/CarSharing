using CarSharing.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSharing.Core.Models
{
    public class Car
    {
        public int Id { get; set; }
        public Model Model { get; set; }
        public string CarPlateNumber { get; set; }
        public Location Location { get; set; }
        public double FuelLeft { get; set; }
    }
}
