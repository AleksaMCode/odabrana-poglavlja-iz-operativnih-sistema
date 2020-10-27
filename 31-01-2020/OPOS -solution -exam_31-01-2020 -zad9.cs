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
            while((line = Console.ReadLine()) != null)
            {
                int len = split = line.Split(" ").Length;
                if(line.Length > 100)
                {
                    Console.WriteLine("{0}\t{1}", len, line);
                }
            }   
        }
    }
}