using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day1_1
    {
        public static void Execute()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\DSU\\source\\repos\\AdventOfCode2023\\AdventOfCode2023\\Day1.txt");
                line = sr.ReadLine();

                double maxCalories = 0;
                double sumOfCalories = 0;

                while (line != null)
                {
                    while (!string.IsNullOrEmpty(line))
                    {
                        sumOfCalories += Convert.ToDouble(line);
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    if (sumOfCalories > maxCalories)
                    {
                        maxCalories = sumOfCalories;
                        Console.WriteLine("New max calories: " + maxCalories);
                    }
                    sumOfCalories = 0;
                    line = sr.ReadLine();
                }
                Console.WriteLine("Max amount of calories: " + maxCalories);
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
