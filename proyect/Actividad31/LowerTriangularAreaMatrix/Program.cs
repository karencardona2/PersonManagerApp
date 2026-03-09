using System;

namespace MatrixExercises
{
    public class LowerTriangularMatrix
    {
        private int[,] _data;
        private int _order;

        public int Order => _order;

        public LowerTriangularMatrix(int n)
        {
            _order = n;
            _data = new int[n, n];
            FillMatrix();
        }

        private void FillMatrix()
        {
            for (int row = 0; row < _order; row++)
            {
                for (int col = 0; col < _order; col++)
                {
                    _data[row, col] = row + col;
                }
            }
        }

        public int GetValue(int row, int col) => _data[row, col];

        public bool IsLowerTriangular(int row, int col)
        {
            return row >= col;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese orden de la matriz: ");
            
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                LowerTriangularMatrix matrix = new LowerTriangularMatrix(n);

                Console.WriteLine("\nMATRIZ COMPLETA:");
                PrintMatrix(matrix, showFull: true);

                Console.WriteLine("\nTRIANGULAR INFERIOR:");
                PrintMatrix(matrix, showFull: false);
            }
            else
            {
                Console.WriteLine("Error: Por favor, ingrese un número entero válido.");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        static void PrintMatrix(LowerTriangularMatrix matrix, bool showFull)
        {
            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    if (showFull || matrix.IsLowerTriangular(i, j))
                    {
                        Console.Write(matrix.GetValue(i, j).ToString().PadLeft(4));
                    }
                    else
                    {
                        Console.Write("    ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}