using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace SandBox
{
    public class BallotBox
    {
        public BallotBox(IEnumerable<Counter> counters)
        {
            Counters = new List<Counter>();
            Counters.AddRange(counters);
        }

        private List<Counter> Counters { get; }

        public int Total() => Counters.Sum(x => x.Count);
        //If there is a tie at the top, we want to make sure we get them all in GetWinner()
        public IEnumerable<Counter> GetWinner()
        {
            var winner = Counters
                .GroupBy(x => x.Count)
                .OrderByDescending(x => x.Key)
                .FirstOrDefault();
            return winner;
        }

        public void ReportResults()
        {
            var sortedList = Counters.OrderByDescending(x => x);
            WriteLine($"Total votes: {Total()}");
            foreach (var counter in sortedList)
            {
                WriteLine($"{counter}: {counter.GetPercent(Total()):F}%");
            }

            WriteLine(GetWinner().ToList().Count == 1 ? "The winner is:" : "The winners are:");
            foreach (var counter1 in GetWinner())
            {
                WriteLine(counter1.Name);
            }

        }
    }
}
