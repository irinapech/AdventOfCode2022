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

            int priorityOfa = 1;
            int priorityOfA = 27;

            int sumOfPriorities = 0;

            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repos\\AdventOfCode2022\\AdventOfCode2022\\Day3.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    line2 = sr.ReadLine();
                    var commonBetween1and2 = line.Intersect(line2);
                    line2 = sr.ReadLine();
                    var commonBetween2and3 = commonBetween1and2.Intersect(line2);
                    foreach (char c in commonBetween2and3)
                    {
                        if (char.IsLower(c))
                        {
                            sumOfPriorities += Convert.ToInt32(c) - Convert.ToInt32('a') + priorityOfa;
                        }
                        else
                        {
                            sumOfPriorities += Convert.ToInt32(c) - Convert.ToInt32('A') + priorityOfA;
                        }
                    }
                    line = sr.ReadLine();
                }
                Console.WriteLine(sumOfPriorities);
                Console.ReadLine();
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
