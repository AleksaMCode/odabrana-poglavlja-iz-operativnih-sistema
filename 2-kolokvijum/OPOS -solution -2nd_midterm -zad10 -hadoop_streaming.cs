using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            var pairs = new List<Tuple<int, string>>();

            while ((line = Console.ReadLine()) != null)
            {
                string[] twoValues = line.Trim().Split('\t');
                pairs.Add(new Tuple<int, string>(Convert.ToInt32(twoValues[0]), twoValues[1]));
            }
            pairs = pairs.Where(pair => pair.Item1 > 2018 && pair.Item2.StartsWith("On")).OrderBy(pair => pair.Item1).ToList(); // ascending sort by key value

            foreach (var pair in pairs)
            {
                Console.WriteLine("{0}\t{1}", pair.Item1, pair.Item2);
            }
        }
    }
}