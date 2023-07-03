using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day4_2
    {
        public static void Execute()
        {
            String line;
            string firstElf, secondElf;
            int numberOfPairsOverlapping = 0;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repos\\AdventOfCode2022\\AdventOfCode2022\\Day4.txt");

                line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    firstElf = line.Substring(0, line.IndexOf(','));
                    secondElf = line.Substring(line.IndexOf(',') + 1);

                    int firstElfStart = Convert.ToInt32(firstElf[..firstElf.IndexOf('-')]);
                    int firstElfEnd = Convert.ToInt32(firstElf.Substring(firstElf.IndexOf('-') + 1));

                    int secondElfStart = Convert.ToInt32(secondElf[..secondElf.IndexOf('-')]);
                    int secondElfEnd = Convert.ToInt32(secondElf.Substring(secondElf.IndexOf('-') + 1));

                    if (firstElfStart >= secondElfStart && firstElfStart <= secondElfEnd
                        || firstElfEnd >= secondElfStart && firstElfEnd <= secondElfEnd
                        || secondElfStart >= firstElfStart && secondElfStart <= firstElfEnd
                        || secondElfEnd >= firstElfStart && secondElfEnd <= firstElfEnd)
                    {
                        numberOfPairsOverlapping++;
                    }

                    line = sr.ReadLine();
                }
                Console.WriteLine("Number of overlapping pairs: " + numberOfPairsOverlapping);
                sr.Close();
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
