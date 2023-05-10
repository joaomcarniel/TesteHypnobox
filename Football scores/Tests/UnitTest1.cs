using Football_scores;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CalculateWinTie()
        {
            int[] teamA = { 4, 5, 6 };
            int[] teamB = { 1, 2, 3 };
            Calculator calculator = new Calculator();

            var winsOrTies = calculator.CalculateWinTie(teamA, teamB);
            Assert.StrictEqual(teamB.ToList().Count, winsOrTies.Count);
        }
    }
}