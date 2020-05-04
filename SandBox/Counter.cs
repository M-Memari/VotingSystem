using System;
using System.Collections.Generic;
using System.Text;

namespace SandBox
{
    public class Counter : IComparable<Counter>
    {
        public Counter(string name, int count)
        {
            Name = name;
            Count = count;
        }
        public string Name { get; }
        public int Count { get; }

        public double GetPercent(int total)
        {
            return 100.0 * Count / total;
        }

        public int CompareTo(Counter other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            //var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
            //if (nameComparison != 0) return nameComparison;
            return Count.CompareTo(other.Count);
        }

        public override string ToString()
        {
            return $"{Name}: {Count} votes";
        }
    }
}
