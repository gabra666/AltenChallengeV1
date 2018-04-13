namespace AltenChallengeV1.DTO
{
    public class VehicleDTO
    {
        public string VehicleID { get; set; }
        public string RegisterNumber { get; set; }

        public int CustomerID { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}