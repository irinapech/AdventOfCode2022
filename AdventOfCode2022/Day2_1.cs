using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day2_1
    {
        public static void Execute()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repos\\AdventOfCode2022\\AdventOfCode2022\\Day2.txt");
                line = sr.ReadLine();

                string[] choices;
                int totalPoints = 0;
                int distanceBetweenLetters = Convert.ToInt32('X' - 'A');
                int lossPoints = 0;
                int drawPoints = 3;
                int winPoints = 6;

                while (line != null)
                {
                    choices = line.Split(' ');
                    int points = Convert.ToInt32(Convert.ToChar(choices[1]));
                    totalPoints += points - Convert.ToInt32('W');
                    if (Convert.ToInt32(Convert.ToChar(choices[1])) -Convert.ToInt32(Convert.ToChar(choices[0])) == distanceBetweenLetters)
                    {
                        totalPoints += drawPoints; // it's a draw
                    }
                    if (choices[0] == "A" && choices[1] == "Z"
                        || choices[0] == "B" && choices[1] == "X"
                        || choices[0] == "C" && choices[1] == "Y")
                    {
                        totalPoints += lossPoints; // it's a loss
                    }
                    if (choices[0] == "A" && choices[1] == "Y"
                        || choices[0] == "B" && choices[1] == "Z"
                        || choices[0] == "C" && choices[1] == "X")
                    {
                        totalPoints += winPoints; // it's a win
                    }
                    line = sr.ReadLine();
                }
                Console.WriteLine("Total points: " + totalPoints);
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
