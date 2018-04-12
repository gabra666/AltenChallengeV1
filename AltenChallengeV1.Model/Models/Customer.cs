using System;
using System.Collections.Generic;
using System.Text;

namespace AltenChallengeV1.Model.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
