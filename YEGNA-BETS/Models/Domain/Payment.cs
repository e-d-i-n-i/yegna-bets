using System.ComponentModel.DataAnnotations;

namespace YEGNA_BETS.Models.Domain
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }
        public string Method { get; set; }
        public string Key { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
