using System;

namespace pr_1_
{
    public class Task1: Task
    {
        public override void Execute()
        {
            int[] numbers = {-6, 2, 21};
            int minNumber = 1;
            int maxNumber = 10 + 9; // 9 - порядковий номер
        
            Console.Write("\n------------------- TASK 1 ------------------\n");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Checking number " + numbers[i] + "...");
                if (numbers[i] >= minNumber && numbers[i] <= maxNumber)
                {
                    Console.WriteLine("Number " + numbers[i] + " is in range [" + minNumber + "-" + maxNumber + "]");
                }
            }
        }
    }
}