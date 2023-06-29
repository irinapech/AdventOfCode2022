using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day3_1
    {
        public static void Execute()
        {
            String line;
            try
            {
                int sumOfPriorities = 0;
                int priorityOfa = 1;
                int priorityOfA = 27;
                string rucksack1, rucksack2;
                bool foundSameItems = false;

                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repos\\AdventOfCode2022\\AdventOfCode2022\\Day3.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    rucksack1 = line.Substring(0, (int)(line.Length / 2));
                    rucksack2 = line.Substring((int)line.Length / 2, (int)line.Length / 2);
                    foundSameItems = false;

                    foreach (char item1 in rucksack1)
                    {
                        foreach (char item2 in rucksack2)
                        {
                            if (item1 == item2)
                            {
                                Console.WriteLine(item1);
                                if (char.IsLower(item1))
                                {
                                    sumOfPriorities += Convert.ToInt32(item1) - Convert.ToInt32('a') + priorityOfa;
                                }
                                else
                                {
                                    sumOfPriorities += Convert.ToInt32(item1) - Convert.ToInt32('A') + priorityOfA;
                                }
                                foundSameItems = true;
                                break;
                            }
                        }
                        if (foundSameItems)
                        {
                            break;
                        }
                    }

                    line = sr.ReadLine();
                }
                Console.WriteLine("Sum of priorities: " + sumOfPriorities);
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

