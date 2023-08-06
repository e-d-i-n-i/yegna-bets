using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YEGNA_BETS.Models.Domain
{
    public class News
    {
        [Key]
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        [ForeignKey("ApplicationUser")]
        public string Encoder { get; set; }
        public ApplicationUser User { get; set; }
        public string? Image { get; set; }
        public int Like { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
