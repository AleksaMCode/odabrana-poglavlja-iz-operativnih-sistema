using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;

            while ((line = Console.ReadLine()) != null)
            {
                line = line.Trim();
                Regex rgx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                string[] lineSplit = line.Split(' ');
                foreach (string pieceOfLine in lineSplit)
                {
                    foreach (Match match in rgx.Matches(pieceOfLine))
                    {
                        string matchString = match.ToString();
                        Console.WriteLine("{0}\t{1}", matchString.Split('@')[0], matchString.Split('@')[1]);
                    }
                }
            }
        }
    }
}