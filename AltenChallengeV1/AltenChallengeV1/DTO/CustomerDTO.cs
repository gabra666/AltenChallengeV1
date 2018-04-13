using System.Collections.Generic;

namespace AltenChallengeV1.DTO
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public List<VehicleDTO> Vehicles { get; set; }
    }
}