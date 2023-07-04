using System.Reflection;
using System.Runtime.InteropServices;

namespace AdventOfCode2022
{
    public static class Day7_1
    {
        public static void Execute()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repos\\AdventOfCode2022\\AdventOfCode2022\\Day7.txt");

                line = sr.ReadLine();

                Dictionary<string, int> fileSizes = new Dictionary<string, int>();
                Dictionary<string, List<string>> directoriesNames = new Dictionary<string, List<string>>();

                string currentDirectory = "/";
                string directoryName;

                int totalSizeOfAtMost100000 = 0;
                int maxSize = 100000;

                while (line != null)
                {
                    Console.WriteLine(line);

                    if (line == "$ cd /")
                    {
                        fileSizes["/"] = 0;
                        directoriesNames["/"] = new List<string>();
                        currentDirectory = "/";
                        line = sr.ReadLine();

                    }
                    if (line == "$ ls")
                    {
                        line = sr.ReadLine();
                        while (line != null && !line.Contains("$"))
                        {
                            if (char.IsDigit(line[0]))
                            {
                                string[] lineSplit = line.Split(' ');
                                int size = Convert.ToInt32(lineSplit[0]);
                                fileSizes[currentDirectory] += size;
                            }
                            //if (line.Contains("dir"))
                            //{
                            //    directoryName = line.Substring(line.IndexOf(' '));
                            //    directoriesNames[currentDirectory].Add(directoryName);
                            //}
                            line = sr.ReadLine();
                        }
                    }
                    if (line != null && line.Contains("cd") && !line.Contains(".."))
                    {
                        directoryName = line.Substring(line.IndexOf('d') + 1);
                        directoriesNames[currentDirectory].Add(directoryName);
                        currentDirectory = directoryName;
                        directoriesNames[currentDirectory] = new List<string>();
                        fileSizes[currentDirectory] = 0;
                    }

                    if (line != null && line == "$ cd ..")
                    {
                        foreach(string directory in directoriesNames[currentDirectory])
                        {
                            fileSizes[currentDirectory] += fileSizes[directory];
                        }
                        
                        if (fileSizes[currentDirectory] <= maxSize)
                        {
                            totalSizeOfAtMost100000 += fileSizes[currentDirectory];
                        }

                        foreach (KeyValuePair <string, List<string>> pair in directoriesNames)
                        {
                            if (pair.Value.Contains(currentDirectory))
                            {
                                fileSizes[pair.Key] += fileSizes[currentDirectory];
                                currentDirectory = pair.Key;
                                break;
                            }
                        }
                    }
                    line = sr.ReadLine();
                }

                //Console.WriteLine();
                //foreach (KeyValuePair<string, List<string>> pair in directoriesNames)
                //{
                //    Console.WriteLine("\nKey = {0}", pair.Key);
                //    foreach (string directory in  pair.Value)
                //    {
                //        Console.WriteLine(directory);
                //    }
                //}

                //Console.WriteLine();
                //foreach (KeyValuePair<string, int> pair in fileSizes)
                //{
                //    Console.WriteLine("\nKey = {0}, Value = {1}", pair.Key, pair.Value);
                //}

                Console.WriteLine("The sum of total sizes of directories < 100000: " + totalSizeOfAtMost100000);

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
