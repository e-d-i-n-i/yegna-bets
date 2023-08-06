using System.ComponentModel.DataAnnotations;

namespace YEGNA_BETS.Models.Domain
{
    public class Pattern
    {
        [Key]
        public Guid Id { get; set; }
        public string Patterns { get; set; }
        public int NoMatches { get; set; }
        public int successCount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
