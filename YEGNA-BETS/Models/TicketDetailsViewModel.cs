using System.ComponentModel.DataAnnotations.Schema;

namespace YEGNA_BETS.Models
{
    public class TicketDetailsViewModel
    {
        public Guid Id { get; set; }
        public string TicketCode { get; set; }
        public int Value { get; set; }
        public int IsUsed { get; set; }
        public string PackageType { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
