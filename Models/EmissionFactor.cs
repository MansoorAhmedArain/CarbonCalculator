namespace WTechAuth.Models
{
    public class EmissionFactor
    {
        public int Id { get; set; }
        public string FuelType { get; set; }
        public decimal Factor { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
