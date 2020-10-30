using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int key = 0;

            while ((line = Console.ReadLine()) != null)
            {
                line = line.Trim().Replace(",", "").Replace(".", "").ToLower();
                string[] words = line.Split(' ');
                foreach (string word in words)
                {
                    Console.WriteLine("{0}\t{1}", key++, word);
                }
            }
        }
    }
}