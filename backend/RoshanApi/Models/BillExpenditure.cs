namespace RoshanApi.Models
{
    public class BillExpenditure
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public string Name { get; set; }
        public string Calculation { get; set; }
        public int Cost { get; set; }
        public int TotalCost { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
