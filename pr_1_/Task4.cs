using System;
using System.Linq;

namespace pr_1_
{
    public class Task4: Task
    {
        public override void Execute()
        { 
            const int m = 5;
            const int x = 10 + 9;

            int[] numbers = new int[x];
            int[] validNumbers = new int[x];

            var rnd = new Random();
            var validCount = 0;

            for (var i = 0; i < x; i++)
            {
                numbers[i] = rnd.Next(-20, 20);
            }

            for (var i = 0; i < x; i++)
            {
                if (Math.Abs(numbers[i]) > m)
                {
                    validNumbers[validCount] = numbers[i];
                    validCount++;
                }
            }

            Console.Write("\n------------------- TASK 4 ------------------\n");
            Console.Write("Initial numbers: ");
            for (var j = 0; j < x; j++)
            {
                Console.Write(numbers[j] + " ");
            }
            Console.Write($"\nValid numbers [M = {m}]: ");
            for (var j = 0; j < validCount; j++)
            {
                Console.Write(validNumbers[j] + " ");
            }
        }
    }
}