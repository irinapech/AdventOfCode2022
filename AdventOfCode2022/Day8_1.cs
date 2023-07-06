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

                List<string> input = new List<string>();

                line = sr.ReadLine();

                while (line != null)
                {
                    input.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();

                int numberOfRows = input.Count;
                int numberOfColumns = input[0].Length;

                int[,] treeHeights = new int[numberOfRows, numberOfColumns];

                for (int i = 0; i <  numberOfRows; i++)
                {
                    for (int j = 0; j < numberOfColumns; j++)
                    {
                        treeHeights[i, j] = Convert.ToInt32(Char.GetNumericValue(input[i][j]));
                    }
                }

                int[,] treesVisibility = new int[numberOfRows, numberOfColumns];
                int maxHeight;

                for (int i = 0; i < numberOfRows; i++)
                {
                    for (int j = 0; j < numberOfColumns; j++)
                    {
                        treesVisibility[i, j] = 0;
                    }
                }

                // iterating from left to right
                for (int i = 1; i < numberOfRows - 1; i++)
                {
                    maxHeight = treeHeights[i, 0]; // making the leftmost tree the highest
                    for (int j = 1; j < numberOfColumns - 1; j++)
                    {
                        if (treeHeights[i, j] >= maxHeight)
                        {
                            maxHeight = treeHeights[i, j];
                            treesVisibility[i, j] = 1;
                        }
                    }
                }

                // iterating from right to left
                for (int i = 1; i < numberOfRows - 1; i++)
                {
                    maxHeight = treeHeights[i, numberOfColumns - 1]; // making the rightmost tree the highest
                    for (int j = numberOfColumns - 2; j > 0; j--)
                    {
                        if (treeHeights[i, j] >= maxHeight)
                        {
                            maxHeight = treeHeights[i, j];
                            treesVisibility[i, j] = 1;
                        }
                    }
                }

                // iterating from top to bottom
                for (int i = 1; i < numberOfColumns - 1; i++)
                {
                    maxHeight = treeHeights[0, i];
                    for (int j = 1; j < numberOfRows - 1; j++)
                    {
                        if (treeHeights[j, i] >= maxHeight)
                        {
                            maxHeight = treeHeights[j, i];
                            treeHeights[j, i] = 1;
                        }
                    }
                }

                // iterating from bottom to top
                for (int i = 1; i < numberOfColumns - 1; i++)
                {
                    maxHeight = treeHeights[numberOfRows - 1, i];
                    for (int j = numberOfRows - 2; j > 0; j--)
                    {
                        if (treeHeights[j, i] >= maxHeight)
                        {
                            maxHeight = treeHeights[j, i];
                            treeHeights[j, i] = 1;
                        }
                    }
                }

                int numberOfVisibleTrees = 0;

                for (int i = 1; i <  numberOfRows - 1; i++)
                {
                    for (int j = 1; j < numberOfColumns - 1; j++)
                    {
                        if (treesVisibility[i, j] == 1)
                        {
                            numberOfVisibleTrees += 1;
                        }
                    }
                }

                //Console.WriteLine("Trees visibility: ");
                //for (int i = 0; i < numberOfRows; i++)
                //{
                //    for (int j = 0; j < numberOfColumns; j++)
                //    {
                //        Console.Write(treesVisibility[i, j] + " ");
                //    }
                //    Console.WriteLine();
                //}

                int numberOfEdgeTrees = 2 * numberOfColumns + 2 * (numberOfRows - 2);
                Console.WriteLine("Number of edge trees: " + numberOfEdgeTrees);
                numberOfVisibleTrees += numberOfEdgeTrees;

                Console.WriteLine("Number of visible trees: " + numberOfVisibleTrees);

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
