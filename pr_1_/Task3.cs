using System;
using System.Linq;

namespace pr_1_
{
    public class Task3: Task
    {
        public override void Execute()
        {
            int x = 10 + 9;
            int[] numbers = new int[x];

            Random rnd = new Random();

            Console.Write("\n------------------- TASK 3 ------------------\n");
            Console.Write("Array: ");
            for (int i = 0; i < x; i++)
            {
                numbers[i] = rnd.Next(-20, 20);
                Console.Write(numbers[i] + " ");
            }
            
            Console.WriteLine("\nMin value: " + numbers.Min());
            Console.WriteLine("Max value: " + numbers.Max());
        }
    }
}