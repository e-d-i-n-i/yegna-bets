using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YEGNA_BETS.Models.Domain
{
    public class Match
    {
        [Key]
        public Guid Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public double OddForHomeTeam { get; set; }
        public double OddForAwayTeam { get; set; }
        public double OddForDraw { get; set; }
        public int Outcome { get; set; }
        [ForeignKey("Bet")]
        public Guid BetId { get; set; }
        public Bet BetCode { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
