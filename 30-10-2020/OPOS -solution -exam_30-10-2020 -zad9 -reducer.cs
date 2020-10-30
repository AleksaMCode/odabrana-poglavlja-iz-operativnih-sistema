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
            int count = 0;

            while ((line = Console.ReadLine()) != null)
            {
                string word = line.Trim().Split('\t')[1];
                string prefix = word[0].ToString() + word[0].ToString() + word[0].ToString() + word[0].ToString();
                if (word.Length >= 4 && word.StartsWith(prefix))
                {
                    count++;
                }
            }
            Console.WriteLine("{0}", count);
        }
    }
}