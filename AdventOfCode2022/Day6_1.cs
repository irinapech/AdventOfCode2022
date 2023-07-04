namespace AdventOfCode2022
{
    public static class Day6_1
    {
        public static void Execute()
        {
            static bool OnlyOnceCheck(string input)
            {
                return input.GroupBy(x => x).Any(g => g.Count() > 1);
            }

            String line;
            int numberOfCharsInMarker = 4;

            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repos\\AdventOfCode2022\\AdventOfCode2022\\Day6.txt");

                line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);

                    for (int i = 0; i < line.Length - numberOfCharsInMarker; i++)
                    {
                        string marker = line.Substring(i, numberOfCharsInMarker);
                        if (!OnlyOnceCheck(marker))
                        {
                            Console.WriteLine(i + numberOfCharsInMarker);
                            break;
                        }
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
