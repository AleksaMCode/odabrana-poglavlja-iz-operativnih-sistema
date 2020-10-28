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
                pairs.Add(new Tuple<double,double>(Convert.ToDouble(twoValues[0]), Convert.ToDouble(twoValues[1])));
            }
            pairs = pairs.OrderBy(pair => pair.Item1).ToList(); // ascending sort by key value
            
            double max = pairs[pairs.Count - 1].Item1;
            double n = pairs[0].Item1;

            while (n < max)
            {
                var keysInRange = pairs.Where(pair => pair.Item1 >= n && pair.Item1 < n + 1.0).ToList(); // finding keys in range [n,n+1)
                if(keysInRange.Count == 1)
                {
                    n += 1.0;
                    continue;
                }
                double averageValue = keysInRange.Sum(pair => pair.Item2) / keysInRange.Count;
                
                pairs = pairs.Except(keysInRange).ToList();
                foreach(var element in keysInRange)
                {
                    pairs.Add(new Tuple<double, double>(element.Item1, averageValue));
                }
                pairs = pairs.OrderBy(pair => pair.Item1).ToList(); // ascending sort by key value

                n += 1.0;
            }

            foreach (Tuple<double, double> pair in pairs)
            {
                Console.WriteLine("{0}\t{1}", pair.Item1, pair.Item2);
            }
        }
    }
}