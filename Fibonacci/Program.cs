using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int fibNumberCurrent = 0;
            int fibNumberPrevious = 0;
            int fibNumberNext = 0;

            Console.WriteLine("Please enter a positive integer");
            string numberInput = Console.ReadLine();
            int numberInputAsAnInteger = int.Parse(numberInput);
            Console.WriteLine();

            while (fibNumberCurrent <= numberInputAsAnInteger)
            {
                if (fibNumberCurrent == 0)
                {
                    Console.Write("The Fibonacci number sequence leading up to your number is: " + fibNumberCurrent);
                    fibNumberPrevious = fibNumberCurrent;
                    fibNumberCurrent = fibNumberCurrent + 1;
                   
                }
                else 
                {
                    Console.Write(", " + fibNumberCurrent);
                    fibNumberNext = fibNumberCurrent + fibNumberPrevious;
                    fibNumberPrevious = fibNumberCurrent;
                    fibNumberCurrent = fibNumberNext;
                }

            }
            Console.ReadLine();

            

           
        }
    }
}
