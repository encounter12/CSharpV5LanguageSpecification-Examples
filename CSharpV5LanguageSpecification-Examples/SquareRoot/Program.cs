using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write squared number: ");
            decimal square = decimal.Parse(Console.ReadLine());

            decimal squareRoot = CalculateSquareRoot(square);

            Console.WriteLine("Squre root of {0} is: {1:0.00}", square, squareRoot);
        }

        public static decimal CalculateSquareRoot(decimal square)
        {
            decimal downLimit = 0.00M;

            decimal upperLimit = 10.00M;

            decimal squareRoot;

            while (true)
            {
                if (square == downLimit * downLimit)
                {
                    squareRoot = downLimit;
                    break;
                }
                else if (square == upperLimit * upperLimit)
                {
                    squareRoot = upperLimit;
                    break;
                }
                else if (square < upperLimit * upperLimit)
                {
                    upperLimit = downLimit + (upperLimit - downLimit) / 2;
                }
                else if (square > upperLimit * upperLimit)
                {
                    decimal tempUpperLimit = upperLimit;
                    upperLimit = upperLimit * 2;
                    downLimit = tempUpperLimit;
                }

                decimal precision = 0.00001M;

                if (upperLimit * upperLimit - square > 0M && upperLimit * upperLimit - square < precision)
                {
                    squareRoot = upperLimit;
                    break;
                }
                else if (square - downLimit * downLimit > 0M && square - downLimit * downLimit < precision)
                {
                    squareRoot = downLimit;
                    break;
                }
            }

            return squareRoot;
        }
    }
}
