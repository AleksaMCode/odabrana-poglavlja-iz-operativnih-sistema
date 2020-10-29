using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reducer
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            List<Tuple<double, double>> pairs = new List<Tuple<double, double>>();
            List<Tuple<double, double>> newPairs = new List<Tuple<double, double>>();


            while ((line = Console.ReadLine()) != "")
            {
                string[] twoValues = line.Trim().Split(' ');
                pairs.Add(new Tuple<double, double>(Convert.ToDouble(twoValues[0]), Convert.ToDouble(twoValues[1])));
            }
            pairs = pairs.OrderBy(pair => pair.Item1).ToList(); // ascending sort by key value

            while (pairs.Count() > 0)
            {
                double n = pairs[0].Item1;
                var keysInRange = pairs.Where(pair => pair.Item1 >= n && pair.Item1 < n + 1.0).ToList(); // finding keys in range [n,n+1)

                if (keysInRange.Count > 1)
                {
                    double averageValue = keysInRange.Sum(pair => pair.Item2) / keysInRange.Count;

                    foreach (var element in keysInRange)
                    {
                        newPairs.Add(new Tuple<double, double>(element.Item1, averageValue));
                        pairs.Remove(element);
                    }
                }
                else
                {
                    pairs.Remove(keysInRange[0]);
                    newPairs.AddRange(keysInRange);
                }
            }

            newPairs = newPairs.OrderBy(pair => pair.Item1).ToList(); // ascending sort by key value
            foreach (Tuple<double, double> pair in newPairs)
            {
                Console.WriteLine("{0}\t{1}", pair.Item1, pair.Item2);
            }
        }
    }
}