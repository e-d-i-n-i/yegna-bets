using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YEGNA_BETS.Models.Domain
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Ticket Ticket { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
