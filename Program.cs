using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class Program
    {
        static void Main(string[] args)
        {
            // Read input values
            Console.Write("Enter number of items: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter item {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            // Sort the array
            Array.Sort(arr);

            // Calculate median
            double median;
            if (n % 2 == 0)
            {
                median = (arr[n / 2 - 1] + arr[n / 2]) / 2.0;
            }
            else
            {
                median = arr[n / 2];
            }
            Console.WriteLine($"Median: {median}");

            // Calculate mode
            int mode = arr.GroupBy(x => x)
                          .OrderByDescending(g => g.Count())
                          .Select(g => g.Key)
                          .FirstOrDefault();
            Console.WriteLine($"Mode: {mode}");

            // Calculate range
            int range = arr[n - 1] - arr[0];
            Console.WriteLine($"Range: {range}");

            // Calculate first quartile
            double q1;
            if (n % 4 == 0)
            {
                q1 = (arr[n / 4 - 1] + arr[n / 4]) / 2.0;
            }
            else
            {
                q1 = arr[n / 4];
            }
            Console.WriteLine($"First Quartile: {q1}");

            // Calculate third quartile
            double q3;
            if (n % 4 == 0)
            {
                q3 = (arr[3 * n / 4 - 1] + arr[3 * n / 4]) / 2.0;
            }
            else
            {
                q3 = arr[3 * n / 4];
            }
            Console.WriteLine($"Third Quartile: {q3}");

            // Calculate P90
            int p90Index = (int)Math.Ceiling(0.9 * n) - 1;
            int p90 = arr[p90Index];
            Console.WriteLine($"P90: {p90}");

            // Calculate interquartile range
            double iqr = q3 - q1;
            Console.WriteLine($"Interquartile Range: {iqr}");

            // Calculate outlier boundaries
            double lowerBound = q1 - 1.5 * iqr;
            double upperBound = q3 + 1.5 * iqr;
            Console.WriteLine($"Outlier Boundaries: [{lowerBound}, {upperBound}]");

            // Determine if an input value is an outlier or not
            Console.Write("Enter a value to check if it's an outlier: ");
            int input = int.Parse(Console.ReadLine());
            if (input < lowerBound || input > upperBound)
            {
                Console.WriteLine($"{input} is an outlier.");
            }
            else
            {
                Console.WriteLine($"{input} is not an outlier.");
            }
        }
    }
}
