using Microsoft.AspNetCore.Identity;

namespace YEGNA_BETS.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? ProfilePic { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public int Access { get; set; }
        public DateTime RegistrationDate { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
