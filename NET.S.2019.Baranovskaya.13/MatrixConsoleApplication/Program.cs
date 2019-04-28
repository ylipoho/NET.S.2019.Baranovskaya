using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericMatrix;

namespace MatrixConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            SymmetricalMatrix<string> symMatrix = new SymmetricalMatrix<string>(3);

            symMatrix.MatrixEvent += Handler2;

            symMatrix[1, 2] = "abc";

            symMatrix[0, 1] = "aaa";

            int[] values = new int[] { 10, 20, 30, 40 };

            DiagonalMatrix<int> diagMatrix = new DiagonalMatrix<int>(values);

            SquareMatrix<int>.matrixDelegate del = diagMatrix.Method;

            diagMatrix.MatrixEvent += Handler1;

            diagMatrix[3, 3] = 17;

            SquareMatrix<int> sqMatrix= new SquareMatrix<int>(4);
            sqMatrix[0, 1] = 12;
            sqMatrix[3, 0] = 78;

            SquareMatrix<int> newMatrix = ExtendedMatrix<int>.GetSum(sqMatrix, diagMatrix);

            Console.ReadLine();
        }

        public static void Handler1(int value, int i, int j)
        {
            Console.WriteLine(string.Format("new int value '{0}' at [{1}, {2}]", value, i, j));
        }

        public static void Handler2(string value, int i, int j)
        {
            Console.WriteLine(string.Format("new string value '{0}' at [{1}, {2}]", value, i, j));
        }
    }
}
