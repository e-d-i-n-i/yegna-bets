using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YEGNA_BETS.Models.Domain
{
    public class Club
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("ApplicationUser")]
        public string Encoder { get; set; }
        public ApplicationUser User { get; set; }
        public string Logo { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
