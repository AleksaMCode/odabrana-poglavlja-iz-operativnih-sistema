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

            while ((line = Console.ReadLine()) != null)
            {
                string[] twoValues = line.Trim().Split('\t');
                pairs.Add(Convert.ToDouble(twoValues[1]), Convert.ToDouble(twoValues[2]));
            }
            pairs = pairs.OrderBy(pair => pair.Item1); // ascending sort by key value
            double max = pairs[pairs.Count - 1].Item1;

            double n = pairs[0].Item1;

            while (n <= max)
            {
                var temp = pairs.Where(pair => pair.Item1 >= n && pair.Item1 < n + 1.0).ToList(); // finding keys in range [n,n+1)
                double averageValue = temp.Sum(pair => pair.Item2);
                averageValue /= temp.Count;

                pairs = pairs.Select(pair =>
                {
                    if (pair.Item1 >= n && pair.Item1 < n + 1.0)
                    {
                        pair.Item2 = averageValue;
                    }
                    return pair;
                }).ToList();
                n += 1.0;
            }

            foreach (Tuple<double, double> pair in pairs)
            {
                Console.WriteLine("{0}\t{1}", pair.Item1, pair.Item2);
            }
        }
    }
}