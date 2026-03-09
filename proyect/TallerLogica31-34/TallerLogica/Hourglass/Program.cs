using System;

namespace MatrixExercises
{
    public class HourglassMatrix
    {
        private int[,] _matrix;
        private int _order;

        public int Order => _order;

        public HourglassMatrix(int n)
        {
            if (n % 2 == 0) throw new ArgumentException("N debe ser un número impar.");
            _order = n;
            _matrix = new int[n, n];
            FillMatrix();
        }

        private void FillMatrix()
        {
            for (int row = 0; row < _order; row++)
            {
                for (int col = 0; col < _order; col++)
                {
                    _matrix[row, col] = row + col;
                }
            }
        }

        public int GetValue(int row, int col) => _matrix[row, col];

        public bool IsHourglassPart(int row, int col)
        {
            bool upperTriangle = (col >= row && col <= _order - 1 - row);
            bool lowerTriangle = (col <= row && col >= _order - 1 - row);

            return upperTriangle || lowerTriangle;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese orden de la matriz (N impar): ");
            if (int.TryParse(Console.ReadLine(), out int n) && n % 2 != 0)
            {
                HourglassMatrix hourglass = new HourglassMatrix(n);

                Console.WriteLine("\nMATRIZ COMPLETA");
                PrintMatrix(hourglass, false);

                Console.WriteLine("\nRELOJ DE ARENA");
                PrintMatrix(hourglass, true);
            }
            else
            {
                Console.WriteLine("Entrada no válida. Debe ser un número impar.");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        static void PrintMatrix(HourglassMatrix hourglass, bool onlyHourglass)
        {
            for (int i = 0; i < hourglass.Order; i++)
            {
                for (int j = 0; j < hourglass.Order; j++)
                {
                    if (!onlyHourglass || hourglass.IsHourglassPart(i, j))
                    {
                        Console.Write(hourglass.GetValue(i, j).ToString().PadLeft(4));
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
