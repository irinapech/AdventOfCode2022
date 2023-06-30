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

            int elvesPerGroup = 3;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repos\\AdventOfCode2022\\AdventOfCode2022\\Day3.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    for (int i = 1; i < elvesPerGroup; i++)
                    {
                        line2 = sr.ReadLine();
                        var common = line.Intersect(line2);
                        foreach (var c in common)
                        {
                            Console.WriteLine(c);
                        }
                        Console.ReadLine();
                    }
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
