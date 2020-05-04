using System;
using System.Collections.Generic;
using System.Linq;

namespace SandBox
{
    internal static class Program
    {
        private static void Main()
        {
            //var ballot = new SortedDictionary<string, int> {{"yesVote", 12}, {"NoCount", 25}, {"Maybe", 25}};
            //var (option, count) = ballot.ElementAt(0);
            //Console.WriteLine($"Winner is {option} by {count} votes");
            //CalculatePercentage(ballot);
            //--------------------------------------------
            var myList = new List<Counter>()
            {
                new Counter("yes",324),
                new Counter("no",432),
                new Counter("maybe",436),
                new Counter("sdfe",436),
                new Counter("mdsfe",436),
                new Counter("dSFdf",436),
                new Counter("dsfdSF",436)

            };
            var myBallot = new BallotBox(myList);
            foreach (Counter counter in myBallot.GetWinner())
            {
                Console.WriteLine($"{counter.ToString()}: {counter.GetPercent(myBallot.Total()):F}%");
            }
        }

        //private static void CalculatePercentage(IDictionary<string, int> ballot)
        //{
        //    var total = ballot.Sum(x => x.Value);
        //    foreach (var option in ballot)
        //    {
        //        var percentage = option.Value * 100.0 / total;
        //        Console.WriteLine($"{option.Key}:{percentage:F}%");
        //    }
        //}
    }
}
