using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day3_2
    {
        public static void Execute()
        {
            String line;
            string line2;
            string line3;

            int elvesPerGroup = 3;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repos\\AdventOfCode2022\\AdventOfCode2022\\Day3.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    line2 = sr.ReadLine();
                    var commonBetween1and2 = line.Intersect(line2);
                    line3 = sr.ReadLine();
                    var commonBetween2and3 = commonBetween1and2.Intersect(line3);
                    foreach (var c in commonBetween2and3)
                    {
                        Console.WriteLine(c);
                    }
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
