﻿namespace AltenChallengeV1.Model.Models
{
    public class Vehicle
    {
        public string VehicleID { get; set; }
        public string RegisterNumber { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
