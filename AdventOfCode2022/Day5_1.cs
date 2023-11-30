using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day5_1
    {
        public static void Execute()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repositories\\AdventOfCode2022\\AdventOfCode2022\\Day5.txt");

                line = sr.ReadLine();

                List<string> instructions = new List<string>();

                List<Stack<char>> cratesStack = new List<Stack<char>>(9);

                int crateLocation;
                int offset = 1;
                int charsInColumn = 4;

                for (int i = 0; i < 9; i++)
                {
                    cratesStack.Add(new Stack<char>());
                }

                while (line != null)
                {
                    while (line != "")
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (Char.IsLetter(line[i]))
                            {
                                crateLocation = (i - offset) / charsInColumn;
                                cratesStack[crateLocation].Push(line[i]);
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

                for (int i = 0; i < cratesStack.Count; i++)
                {
                    Stack<char> sortedStack = new Stack<char>();
                    while (cratesStack[i].Count > 0)
                    {
                        sortedStack.Push(cratesStack[i].Pop());
                    }
                    cratesStack[i] = sortedStack;
                }

                //for (int i = 0; i < cratesStack.Count; i++)
                //{
                //    foreach (char c in cratesStack[i])
                //    {
                //        Console.Write(c + " ");
                //    }
                //    Console.Write("\n");
                //}

                //Console.WriteLine("Instructions:\n");
                //foreach (string instruction in instructions)
                //{
                //    Console.WriteLine(instruction);
                //}
                //Console.ReadLine();

                int numberOfCratesToMove;
                int sourcePile;
                int destinationPile;

                foreach (string instruction in instructions)
                {
                    string[] subs = instruction.Split(' ');
                    // Console.WriteLine(instruction);
                    numberOfCratesToMove = Convert.ToInt32(subs[1]);
                    sourcePile = Convert.ToInt32(subs[3]) - 1;
                    destinationPile = Convert.ToInt32(subs[5]) - 1;

                    for (int i = 0; i < numberOfCratesToMove; i++)
                    {
                        cratesStack[destinationPile].Push(cratesStack[sourcePile].Pop());
                    }

                    //Console.WriteLine("\nNew crates position: ");
                    //for (int i = 0; i < cratesStack.Count; i++)
                    //{
                    //    foreach (char c in cratesStack[i])
                    //    {
                    //        Console.Write(c + " ");
                    //    }
                    //    Console.Write("\n");
                    //}
                }

                Console.WriteLine("The top of each stack: ");
                for (int i = 0; i < cratesStack.Count; i++)
                {
                    Console.Write(i + " " + cratesStack[i].Peek());
                    Console.Write("\n");
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
