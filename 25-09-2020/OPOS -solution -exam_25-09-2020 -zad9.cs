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
                string[] twoValues = line.Trim().Split('\t');
                pairs.Add(new Tuple<double, double>(Convert.ToDouble(twoValues[0]), Convert.ToDouble(twoValues[1])));
            }
            pairs = pairs.Where(pair => pair.Item1 >= 0 && pair.Item1 < 100_000).OrderBy(pair => pair.Item1).ToList(); // ascending sort by key value

            int count = pairs.Count();

            while (count > 0)
            {
                double keyValue = pairs[count - 1].Item1;
                if (keyValue - 1 < 0)
                {
                    break;
                }
                
                double n = (keyValue - 1) / 2; // 2n+1=keyValue
                List<Tuple<double, double>> keysInRange = new List<Tuple<double, double>>();

                if (n > 0)
                {
                    keysInRange = pairs.Where(pair => pair.Item1 == keyValue).ToList();
                    keysInRange = keysInRange.Union(pairs.Where(pair => pair.Item1 >= n && pair.Item1 < n + 1.0)).ToList(); // finding keys in range [n,n+1)
                }
                else
                {
                    keysInRange = pairs.Where(pair => pair.Item1 == keyValue).ToList();
                }

                if (keysInRange.Count > 1)
                {
                    double averageValue = keysInRange.Sum(pair => pair.Item2) / keysInRange.Count;

                    foreach (var element in keysInRange)
                    {
                        pairs.Remove(element);
                        newPairs.Add(new Tuple<double, double>(element.Item1, averageValue));
                    }
                }
                else
                {
                    pairs.Remove(keysInRange[0]);
                    newPairs.AddRange(keysInRange);
                }
                count = pairs.Count();
            }

            foreach (Tuple<double, double> pair in newPairs)
            {
                Console.WriteLine("{0}\t{1}", pair.Item1, pair.Item2);
            }
        }
    }
}