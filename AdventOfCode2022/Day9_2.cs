namespace AdventOfCode2022
{
    public static class Day9_2
    {
        public static void Execute()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repos\\AdventOfCode2022\\AdventOfCode2022\\Day9.txt");

                List<string> directions = new List<string>();

                line = sr.ReadLine();

                while (line != null)
                {
                    directions.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();

                string direction = "";
                int steps = 0;

                int HeadXPosition = 0;
                int HeadYPosition = 0;
                int TailXPosition = 0;
                int TailYPosition = 0;

                HashSet<string> tailPositions = new HashSet<string>();

                int[,] rope = new int[,] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };

                foreach (string directionAndSteps in directions)
                {
                    direction = directionAndSteps.Split(' ')[0].ToString();
                    steps = Convert.ToInt32(directionAndSteps.Split(' ')[1]);

                    Console.WriteLine($"Direction: {direction}, Steps: {steps}.");

                    for (int i = 1; i <= steps; i++)
                    {
                        switch (direction)
                        {
                            case "R":
                                HeadXPosition++;
                                break;
                            case "U":
                                HeadYPosition++;
                                break;
                            case "L":
                                HeadXPosition--;
                                break;
                            case "D":
                                HeadYPosition--;
                                break;
                        }

                        rope[0, 0] = HeadXPosition;
                        rope[0, 1] = HeadYPosition;

                        for (int j = 1; j < rope.GetLength(0); j++)
                        {
                            HeadXPosition = rope[j - 1, 0];
                            HeadYPosition = rope[j - 1, 1];
                            TailXPosition = rope[j, 0];
                            TailYPosition = rope[j, 1];


                            if (Math.Abs(HeadXPosition - TailXPosition) == 2 && HeadYPosition == TailYPosition)
                            {
                                if (HeadXPosition > TailXPosition)
                                {
                                    TailXPosition++;
                                }
                                else
                                {
                                    TailXPosition--;
                                }
                            }

                            if (Math.Abs(HeadYPosition - TailYPosition) == 2 && HeadXPosition == TailXPosition)
                            {
                                if (HeadYPosition > TailYPosition)
                                {
                                    TailYPosition++;
                                }
                                else
                                {
                                    TailYPosition--;
                                }
                            }

                            if (HeadXPosition != TailXPosition && Math.Abs(HeadYPosition - TailYPosition) > 1
                                || HeadYPosition != TailYPosition && Math.Abs(HeadXPosition - TailXPosition) > 1)
                            {
                                if (HeadXPosition < TailXPosition)
                                {
                                    TailXPosition--;
                                }
                                if (HeadXPosition > TailXPosition)
                                {
                                    TailXPosition++;
                                }
                                if (HeadYPosition < TailYPosition)
                                {
                                    TailYPosition--;
                                }
                                if (HeadYPosition > TailYPosition)
                                {
                                    TailYPosition++;
                                }

                            }

                            rope[j - 1, 0] = HeadXPosition;
                            rope[j - 1, 1] = HeadYPosition;
                            rope[j, 0] = TailXPosition;
                            rope[j, 1] = TailYPosition;

                            if (j == rope.GetLength(0) - 1)
                            {
                                string tailCurrentPosition = String.Concat('(', TailXPosition, ',', TailYPosition, ')');
                                tailPositions.Add(tailCurrentPosition);
                            }
                        }
                    }
                }
                Console.ReadLine();
                Console.Write("Tailpositions contains {0} elements: ", tailPositions.Count);
                DisplaySet(tailPositions);

                void DisplaySet(HashSet<string> collection)
                {
                    Console.Write("{");
                    foreach (string item in collection)
                    {
                        Console.Write(" {0}", item);
                    }
                    Console.WriteLine(" }");
                }

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
