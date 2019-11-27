using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CarSharing.Core.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
