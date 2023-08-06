namespace YEGNA_BETS.Tools
{
    public class ToolKit
    {
        public string GenerateRandomString(int length)
        {
            // Create a string of all possible characters.
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            // Generate a random string of the specified length.
            string randomString = "";
            for (int i = 0; i < length; i++)
            {
                randomString += characters[new Random().Next(characters.Length)];
            }

            // Return the random string.
            return randomString;
        }
        public static void CalculateOutcomes(int n, string outcome, List<string> outcomes)
        {
            if (n == 0)
            {
                outcomes.Add(outcome);
                return;
            }
            CalculateOutcomes(n - 1, outcome + "W", outcomes);
            CalculateOutcomes(n - 1, outcome + "D", outcomes);
            CalculateOutcomes(n - 1, outcome + "L", outcomes);
        }
    }
}
