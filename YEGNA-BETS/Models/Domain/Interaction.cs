using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YEGNA_BETS.Models.Domain
{
    public class Interaction
    {
        [Key]
        public Guid Id { get; set; }
        public News Post { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int UpOrDown { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
