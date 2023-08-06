using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YEGNA_BETS.Models.Domain
{
    public class UpComingMatch
    {
        [Key]
        public Guid Id { get; set; }
        public Guid HomeTeam { get; set; }
        public Guid AwayTeam { get; set; }
        [ForeignKey("ApplicationUser")]
        public string Encoder { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime MatchDate { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
