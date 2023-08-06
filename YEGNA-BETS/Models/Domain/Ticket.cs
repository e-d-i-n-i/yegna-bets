using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YEGNA_BETS.Models.Domain
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }
        public string TicketCode { get; set; }
        public int IsUsed { get; set; }
        public int Value { get; set; }
        public string Type { get; set; }
        [ForeignKey("ApplicationUser")]
        public Guid packType { get; set; }
        public Package PackageType { get; set; }
       
        [ForeignKey("ApplicationUser")]
        public string Encoder { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
