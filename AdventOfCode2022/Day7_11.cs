using System.Collections;

namespace AdventOfCode2022
{
    public static class Day7_11
    {
        public static void Execute()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repos\\AdventOfCode2022\\AdventOfCode2022\\Day7.txt");

                line = sr.ReadLine();

                Stack directories = new Stack();

                string dirName;

                int fileSize = 0;

                int maxSize = 100000;

                int sumOfMaxSizes = 0;

                while (line != null)
                {
                    if (line.Contains("cd") && !line.Contains("..") || line.EndsWith('/'))
                    {
                        dirName = line.Substring(line.IndexOf('d') + 2);
                        directories.Push(dirName);
                    }

                    if (line.Contains(".."))
                    {   
                        directories.Pop();
                    }

                    if (char.IsDigit(line[0]))
                    {
                        fileSize += Convert.ToInt32(line.Split(' ')[0]);
                    }

                    line = sr.ReadLine();
                }
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
