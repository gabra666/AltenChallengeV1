using System;
using System.Collections.Generic;
using System.Text;

namespace AltenChallengeV1.Model.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
