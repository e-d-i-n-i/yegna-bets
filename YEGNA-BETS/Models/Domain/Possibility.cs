using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YEGNA_BETS.Models.Domain
{
    public class Possibility
    {
        [Key]
        public Guid Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        [ForeignKey("Stake")]
        public Guid stakeCode { get; set; }
        public Stake StakeCode { get; set; }
        public string Outcome { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
