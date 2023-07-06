namespace AdventOfCode2022
{
    internal static class PracticeLoops
    {
        public static void Execute()
        {
            int numberOfRows = 5;
            int numberOfColumns = 5;
            int maxHeight;

            int[,] treeHeights = new int[5, 5] { { 3, 0, 3, 7, 3 }, 
                                                 { 2, 5, 5, 1, 2 }, 
                                                 { 6, 5, 3, 3, 2 }, 
                                                 { 3, 3, 5, 4, 9 }, 
                                                 { 3, 5, 3, 9, 0 } };

            Console.WriteLine("Iterating from left to right:");
            // iterating from left to right
            for (int i = 1; i < numberOfRows - 1; i++)
            {
                maxHeight = treeHeights[i, 0]; // making the leftmost tree the highest
                for (int j = 1; j < numberOfColumns - 1; j++)
                {
                    Console.Write(treeHeights[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Iterating from right to left:");
            for (int i = 1; i < numberOfRows - 1; i++)
            {
                maxHeight = treeHeights[i, numberOfColumns - 1]; // making the rightmost tree the highest
                for (int j = numberOfColumns - 2; j > 0; j--)
                {
                    Console.Write(treeHeights[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Iterating from top to bottom:");
            for (int i = 1; i < numberOfColumns - 1; i++)
            {
                maxHeight = treeHeights[0, i];
                for (int j = 1; j < numberOfRows - 1; j++)
                {
                    Console.Write(treeHeights[j, i] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Iterating from bottom to top:");
            for (int i = 1; i < numberOfColumns - 1; i++)
            {
                maxHeight = treeHeights[numberOfRows - 1, i];
                Console.WriteLine("The bottom tree in line {0} is {1}: ", i, maxHeight);
                for (int j = numberOfRows - 2; j > 0; j--)
                {
                    Console.Write(treeHeights[j, i] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
