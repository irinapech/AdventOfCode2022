﻿using System.Collections;
using System.Data;

namespace AdventOfCode2022
{
    public static class Day7_1
    {
        public static void Execute()
        {
            try
            {
                string line;
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repos\\AdventOfCode2022\\AdventOfCode2022\\Day7.txt");
                List<string> commands = new List<string>();

                line = sr.ReadLine();

                while (line != null)
                {
                    commands.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();

                Dictionary<string, int> sizes = new Dictionary<string, int>();
                Stack<string> stack = new Stack<string>();

                string path;

                int size;

                int maxSize = 100000;

                int sumOfMaxSizes = 0;

                foreach (string command in commands)
                {
                    if (command.StartsWith("$ ls") || command.StartsWith("dir"))
                    {
                        continue;
                    }
                    if (command.StartsWith("$ cd"))
                    {
                        string destination = command.Split(' ')[2];
                        if (destination == "..")
                        {
                            stack.Pop();
                        }
                        else
                        {
                            if (stack.Count > 0)
                            {
                                path = String.Concat(stack.Peek(), '_', destination);
                            }
                            else
                            {
                                path = destination;
                            }
                            stack.Push(path);
                        }
                    }
                    else
                    {
                        size = Convert.ToInt32(command.Split(' ')[0]);
                        foreach(string item in stack)
                        {
                            if (sizes.ContainsKey(item))
                            {
                                sizes[item] += size;
                            }
                            else
                            {
                                sizes.Add(item, size);
                            }
                        }
                    }
                }
                foreach (KeyValuePair<string, int> pair in sizes)
                {
                    if (pair.Value < maxSize)
                    {
                        sumOfMaxSizes += pair.Value;
                    }
                }

                Console.WriteLine("Sum of sizes under 100,000: " + sumOfMaxSizes);
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
