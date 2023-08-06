using System.ComponentModel.DataAnnotations.Schema;
using YEGNA_BETS.Models.Domain;

namespace YEGNA_BETS.Models
{
    public class AddTicketViewModel
    {
        public Guid PackageId { get; set; }
        public string Type { get; set; }

        public int Quantity { get; set; }
    }
}
