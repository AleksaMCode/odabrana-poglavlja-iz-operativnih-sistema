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

            while ((line = Console.ReadLine()) != null)
            {
                string[] twoValues = line.Split('\t');
                pairs.Add(new Tuple<double, double>(Convert.ToDouble(twoValues[0]), Convert.ToDouble(twoValues[1])));
            }
            pairs = pairs.Where(pair => pair.Item1 >= 0 && pair.Item1 < 100_000).OrderBy(pair => pair.Item1).ToList(); // key filtering + ascending sort by key value

            while (pairs.Count() > 0)
            {
                double n = pairs[0].Item1;
                double keyValue = 2 * n + 1.0;
                List<Tuple<double, double>> keysInRange = new List<Tuple<double, double>>();
                double averageValue;

                if (pairs.Any(pair => pair.Item1 == keyValue))
                {
                    keysInRange = pairs.Where(pair => pair.Item1 == keyValue).ToList();
                    keysInRange = keysInRange.Union(pairs.Where(pair => pair.Item1 >= n && pair.Item1 < n + 1.0)).ToList();
                    averageValue = keysInRange.Sum(pair => pair.Item2) / keysInRange.Count;
                }
                else if (pairs.Where(pair => pair.Item1 == n).Count() > 1)
                {
                    keysInRange = pairs.Where(pair => pair.Item1 == n).ToList();
                    averageValue = keysInRange.Sum(pair => pair.Item2) / keysInRange.Count;
                }
                else
                {
                    newPairs.Add(pairs[0]);
                    pairs.RemoveAt(0);
                    continue;
                }

                foreach (var element in keysInRange)
                {
                    pairs.Remove(element);
                    newPairs.Add(new Tuple<double, double>(element.Item1, averageValue));
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

// code tested with values:
//1.0 5.0565
//1.2 656.65
//1.9 18.52
//3.0 565.56
//-3.65 56.656
//3.2 2626.6
//3.2 4564.6
//5.0 595.59
//5.0 556.59
//5.0 5262.26
//9.3 25.595
//100596 59.9659
//9.959 656.959
//9.23 2626.565
//9.23 262.595