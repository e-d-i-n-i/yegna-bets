namespace YEGNA_BETS.Models
{
    public class GetMatchesViewModel
    {
        public int MatchNumber { get; set; } 
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public double OddForHomeTeam { get; set; }
        public double OddForAwayTeam { get; set; }
        public double OddForDraw { get; set; }

        public int UserAvailableBets { get; set; }
    }
}
