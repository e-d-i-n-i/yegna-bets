using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YEGNA_BETS.Models.Domain
{
    public class Logs
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
