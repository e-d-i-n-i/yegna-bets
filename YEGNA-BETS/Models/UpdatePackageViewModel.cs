namespace YEGNA_BETS.Models
{
    public class UpdatePackageViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Value { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
