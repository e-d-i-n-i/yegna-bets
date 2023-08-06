using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YEGNA_BETS.Models.Domain
{
    public class Bet
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public double Budget { get; set; }
        public double TAX { get; set; }
        public double VAT { get; set; }
        public Guid? WinnerStake { get; set; }
        public int NoMatches { get; set; }
        public DateTime Timestamp { get; set; }
        public int IsChecked { get; set; }
    }
}
