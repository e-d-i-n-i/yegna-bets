using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YEGNA_BETS.Models.Domain;

namespace YEGNA_BETS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //New Tables
        public DbSet<Bet> Bet { get; set; }
        public DbSet<Life> Life { get; set; }
        public DbSet<Club> Club { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Interaction> Interaction { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<Pattern> Pattern { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Possibility> Possibility { get; set; }
        public DbSet<Stake> Stake { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<UpComingMatch> UpComingMatch { get; set; }
    }
}