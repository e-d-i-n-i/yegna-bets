using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YEGNA_BETS.Models.Domain
{
    public class Stake
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Bet")]
        public Guid BetId { get; set; }
        public Bet BetCode { get; set; }
        public double TotalOdds { get; set; }
        public double Probability { get; set; }
        public double PayOut { get; set; }
        public string Pattern { get; set; }
        public int IsWinner { get; set; }
        public double? Luck { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
