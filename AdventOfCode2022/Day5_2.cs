using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day5_2
    {
        public static void Execute()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repos\\AdventOfCode2022\\AdventOfCode2022\\Day5.txt");

                line = sr.ReadLine();

                Dictionary<int, List<char>> crates = new Dictionary<int, List<char>>();
                List<string> instructions = new List<string>();

                int crateLocation;
                int offset = 1;
                int charsInColumn = 4;

                while (line != null)
                {
                    while (line != "")
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (Char.IsLetter(line[i]))
                            {
                                crateLocation = (i - offset) / charsInColumn + offset;
                                if (!crates.ContainsKey(crateLocation))
                                {
                                    crates[crateLocation] = new List<char>();
                                }
                                crates[crateLocation].Add(line[i]);
                            }
                        }
                        line = sr.ReadLine();
                    }
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            instructions.Add(line);
                        }
                    }
                }
                sr.Close();

                Console.WriteLine();
                foreach (KeyValuePair<int, List<char>> pair in crates)
                {
                    Console.WriteLine("\nKey = {0}", pair.Key);
                    foreach (char c in pair.Value)
                    {
                        Console.Write(c + " ");
                    }
                }

                Console.WriteLine("\nInstructions: ");
                foreach (string instruction in instructions)
                {
                    Console.WriteLine(instruction);
                }
                Console.ReadLine();

                int numberOfCratesToMove;
                int sourcePile;
                int destinationPile;

                foreach (string instruction in instructions)
                {
                    string[] subs = instruction.Split(' ');
                    Console.WriteLine();
                    Console.WriteLine(instruction);
                    numberOfCratesToMove = Convert.ToInt32(subs[1]);
                    sourcePile = Convert.ToInt32(subs[3]);
                    destinationPile = Convert.ToInt32(subs[5]);

                    crates[destinationPile].InsertRange(0, crates[sourcePile].GetRange(0, numberOfCratesToMove));

                    for (int i = 0; i < numberOfCratesToMove; i++)
                    {
                        crates[sourcePile].RemoveAt(0);
                    }

                    Console.WriteLine("\nNew crates position: ");
                    foreach (KeyValuePair<int, List<char>> pair in crates)
                    {
                        Console.WriteLine("\nKey = {0}", pair.Key);
                        foreach (char c in pair.Value)
                        {
                            Console.Write(c + " ");
                        }
                    }
                }
                foreach (KeyValuePair<int, List<char>> pair in crates)
                {
                    Console.WriteLine("\nKey = {0}, First value = {1}", pair.Key, pair.Value[0]);

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
