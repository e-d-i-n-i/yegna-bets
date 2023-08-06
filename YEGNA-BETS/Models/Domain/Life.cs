using System.ComponentModel.DataAnnotations.Schema;

namespace YEGNA_BETS.Models.Domain
{
    public class Life
    {
        public Guid Id { get; set; }
        public int RemaingBets { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
