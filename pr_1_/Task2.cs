using System;

namespace pr_1_
{
    public class Task2: Task
    {
        public override void Execute()
        {
            Console.Write("\n------------------- TASK 2 ------------------\n");
            double  a = 3,
                    b = 4,
                    c = 5;
            
            Console.WriteLine("a: {0}, b: {1}, c: {2}", a, b, c);
            if (a + b > c && a + c > b && b + c > a)
            {
                double perimeter = a + b + c;
                double semiPerimeter = perimeter / 2;
                double area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));

                Console.WriteLine($"P = {perimeter}");
                Console.WriteLine($"S = {area}");
                
                if (a == b && b == c)
                {
                    Console.WriteLine("The triangle is equilateral.");
                }
                else if (a == b || b == c || a == c)
                {
                    Console.WriteLine("The triangle is isosceles.");
                }
                else
                {
                    Console.WriteLine("The triangle is scalene.");
                }
            }
            else
            {
                Console.WriteLine("Invalid triangle sided.");
            }
        } 
    }
}