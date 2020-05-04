using System;
using System.Collections.Generic;
using System.Linq;

namespace SandBox
{
    public class BallotBox
    {
        public BallotBox(ICollection<Counter> counters)
        {
            Counters = new List<Counter>();
            Counters.AddRange(counters);
        }

        private List<Counter> Counters { get; }

        public int Total() => Counters.Sum(x => x.Count);

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
            Console.WriteLine($"Total votes: {Total()}");
            foreach (Counter counter in sortedList)
            {
                Console.WriteLine($"{counter.ToString()}: {counter.GetPercent(Total()):F}%");
            }
            Console.WriteLine(",therefore the winner/winners is/are:");
            foreach (Counter counter1 in GetWinner())
            {
                Console.WriteLine(counter1.ToString());
            }

        }
    }
}
