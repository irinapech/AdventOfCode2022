using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day8_1
    {
        public static void Execute()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repos\\AdventOfCode2022\\AdventOfCode2022\\Day8.txt");

                List<List<int>> treeHeights = new List<List<int>>();

                line = sr.ReadLine();

                int i, j;

                for (i = 0;  line != null; i++)
                {
                    Console.WriteLine(line);
                    treeHeights[i] = new List<int>();
                    for (j = 0; j < line.Length; j++)
                    {
                        char tree = line[j];
                        treeHeights[i].Add(Convert.ToInt32(tree));
                    }
                    int numberOfColumns = j;
                    line = sr.ReadLine();
                }
                int numberOfRows = i;

                for (int k = 0; k < numberOfRows; k++)
                {
                    for (int l = 0; l < numberOfRows;  l++)
                    {
                        Console.Write(treeHeights[k][l] + " ");
                    }
                    Console.WriteLine("\n");
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
