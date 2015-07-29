using System;

namespace TwoDimensionalArrayReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Number of rows?: ");
            int rows = Convert.ToInt32(Console.ReadLine());

            Console.Write("Number of columns?: ");
            int columns = Convert.ToInt32(Console.ReadLine());

            int[,] array = new int[rows, columns];

            array = PopulateArray(array);

            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write(array[row, col] + " ");
                }

                Console.Write(Environment.NewLine);
            }

            Console.ReadKey();
        }

        static int[,] PopulateArray(int[,] array)
        {
            Random r = new Random();

            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    array[row, col] = r.Next(0, 10);
                }
            }

            return array;
        }

    }
}
