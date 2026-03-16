namespace RoshanApi.Models
{
    public class Expenditure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Calculation { get; set; }
        public int Cost { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
