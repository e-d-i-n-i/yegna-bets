using YEGNA_BETS.Models.Domain;

namespace YEGNA_BETS.Models
{
    public class GetMatchResultViewModel
    {
        public List<Match> matches { get ; set; }
        public Guid BetId { get; set; }
    }
}
