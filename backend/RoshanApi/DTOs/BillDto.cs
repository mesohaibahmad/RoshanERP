using RoshanApi.Models;
using RoshanAPI.Models;

namespace RoshanApi.DTOs
{
    public class BillDto
    {
        public string InvoiceType { get; set; }
        public int SupplierBalance { get; set; }
        public int CustomerBalance { get; set; }
        public List<Transaction> Transactions{ get; set;}
        //public List<BillExpenditure> BillExpenditures{ get; set;}
    }
}
