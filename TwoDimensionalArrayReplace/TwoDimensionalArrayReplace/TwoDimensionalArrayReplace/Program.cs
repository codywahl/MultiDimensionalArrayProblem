using System;
using System.Collections.Generic;

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

            Console.WriteLine();
            WriteArray(array);

            ChangeRowColValueTo0If0ExistsInRowCol(array, 0, 0, new List<int>(), new List<int>());

            Console.WriteLine();
            WriteArray(array);

            Console.ReadKey();
        }

        private static int[,] ChangeRowColValueTo0If0ExistsInRowCol(int[,] array, int row, int col, List<int> colsWith0, List<int> rowsWith0)
        {
            if (array[row, col] == 0)
            {
                colsWith0.Add(col);
                rowsWith0.Add(row);
            }

            if (row == array.GetLength(0) - 1 && col == array.GetLength(1) - 1)
            {
                if (rowsWith0.Contains(row))
                {
                    array[row, col] = 0;
                }
                else if (colsWith0.Contains(col))
                {
                    array[row, col] = 0;
                }

                return array;
            }

            if (col < array.GetLength(1) - 1)
            {
                ChangeRowColValueTo0If0ExistsInRowCol(array, row, col + 1, colsWith0, rowsWith0);
            }
            else
            {
                if (row < array.GetLength(0) - 1)
                {
                    ChangeRowColValueTo0If0ExistsInRowCol(array, row + 1, 0, colsWith0, rowsWith0);
                }
            }

            if (rowsWith0.Contains(row))
            {
                array[row, col] = 0;
            }
            else if (colsWith0.Contains(col))
            {
                array[row, col] = 0;
            }

            return array;
        }

        private static void WriteArray(int[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write(array[row, col] + " ");
                }

                Console.Write(Environment.NewLine);
            }
        }

        private static int[,] PopulateArray(int[,] array)
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
