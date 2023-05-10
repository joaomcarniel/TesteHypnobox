using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_scores
{
    public class Calculator
    {
        public List<int> CalculateWinTie(int[] teamA, int[] teamB)
        {
            var winsOrTies = new List<int>();
            foreach (var goals in teamB)
            {
                var teamBResults = teamA.Where(x => goals >= x).ToList();
                Console.WriteLine($"{teamBResults.Count}");
                winsOrTies.Add(teamBResults.Count);
            }
            return winsOrTies;
        }
    }
}
