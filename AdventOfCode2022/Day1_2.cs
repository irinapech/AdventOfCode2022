using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day1_2
    {
        public static void Execute()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\OneDrive - Dakota State University\\Desktop\\repos\\AdventOfCode2022\\AdventOfCode2022\\Day1.txt");
                line = sr.ReadLine();

                double sumOfCalories = 0;
                double minCalories = 1000000000;
                int minIndex = 0;

                double[] maxCalories = { 0, 0, 0 };

                while (line != null)
                {
                    while (!string.IsNullOrEmpty(line))
                    {
                        sumOfCalories += Convert.ToDouble(line);
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    for (int i = 0; i <  maxCalories.Length; i++)
                    {
                        if (sumOfCalories > minCalories || sumOfCalories > maxCalories[i])
                        {
                            maxCalories[minIndex] = sumOfCalories;
                            minIndex = Array.IndexOf(maxCalories, maxCalories.Min());
                            minCalories = maxCalories.Min();
                            Console.WriteLine("Max amount of calories: ");
                            foreach (double calories in maxCalories)
                            {
                                Console.Write(calories + " ");
                            }
                            break;
                        }
                    }
                    sumOfCalories = 0;
                    line = sr.ReadLine();
                }
                double sumOfMaxCalories = 0;
                Console.WriteLine("\nMax amount of calories: ");
                foreach (double calories in maxCalories)
                {
                    sumOfMaxCalories += calories;
                    Console.Write(calories + " ");
                }
                Console.WriteLine("Sum of max calories: " + sumOfMaxCalories);
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
