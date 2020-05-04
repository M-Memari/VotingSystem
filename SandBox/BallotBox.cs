using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandBox
{
    public class BallotBox
    {
        public BallotBox(ICollection<Counter> counters)
        {
            Counters = new List<Counter>();
            Counters.AddRange(counters);
        }
        public List<Counter> Counters { get; }

        public int Total()
        {
            return Counters.Sum(x => x.Count);
        }

        public IEnumerable<Counter> GetWinner()
        {
            var winner = Counters
                .GroupBy(x => x.Count)
                .OrderByDescending(x => x.Key)
                .FirstOrDefault();
            return winner;
        }
    }
}
