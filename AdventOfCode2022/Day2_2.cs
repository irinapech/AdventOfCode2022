using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day2_2
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
                int pointsForRock = 1;
                int pointsForPaper = 2;
                int pointsForScissors = 3;

                while (line != null)
                {
                    choices = line.Split(' ');

                    if (choices[1] == "Y")
                    {
                        totalPoints += drawPoints; // it's a draw
                        totalPoints += Convert.ToInt32(Convert.ToChar(choices[0])) - Convert.ToInt32('@');
                    }
                    else if (choices[1] == "X")
                    { 
                        totalPoints += lossPoints; // it's a loss
                        if (choices[0] == "A")
                        {
                            totalPoints += pointsForScissors;
                        }
                        if (choices[0] == "B")
                        {
                            totalPoints += pointsForRock;
                        }
                        if (choices[0] == "C")
                        {
                            totalPoints += pointsForPaper;
                        }
                    }
                    else if (choices[1] == "Z")
                    { 
                        totalPoints += winPoints; // it's a win
                        if (choices[0] == "A")
                        {
                            totalPoints += pointsForPaper;
                        }
                        if (choices[0] == "B")
                        {
                            totalPoints += pointsForScissors;
                        }
                        if (choices[0] == "C")
                        {
                            totalPoints += pointsForRock;
                        }
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
