using System.Collections;
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
                    if (!line.StartsWith("$ ls") && !line.StartsWith("dir"))
                    {
                        commands.Add(line);
                        line = sr.ReadLine();
                    }
                }
                sr.Close();

                Dictionary<int, int> sizes = new Dictionary<int, int>();
                List<int> stack = new List<int>();

                string path;
                int size;
                int maxSize = 100000;
                int sumOfMaxSizes = 0;
                for (int i = 0; i < commands.Count; i++)
                {
                    if (commands[i].StartsWith("$ cd"))
                    {
                        string destination = commands[i].Split(' ')[2];
                        if (destination == "..")
                        {
                            stack.RemoveAt(stack.Count - 1);
                        }
                        else
                        {
                            stack.Add(i);
                            sizes[i] = 0;
                        }
                    }
                    else
                    {
                        size = Convert.ToInt32(commands[i].Split(' ')[0]);
                        foreach(int item in stack)
                        {
                            sizes[item] += size;
                        }
                    }
                }
                foreach (KeyValuePair<int, int> pair in sizes)
                {
                    Console.WriteLine($"Key: {0} Value: {1}", pair.Key, pair.Value);
                }
                sumOfMaxSizes = 0;
                foreach (KeyValuePair<int, int> pair in sizes)
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
