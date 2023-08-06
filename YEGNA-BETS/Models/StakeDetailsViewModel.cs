using YEGNA_BETS.Models.Domain;

namespace YEGNA_BETS.Models
{
    public class StakeDetailsViewModel
    {
       public Stake stake { get; set; }

        public List<Possibility> Possibilities { get; set; }
    }
}
