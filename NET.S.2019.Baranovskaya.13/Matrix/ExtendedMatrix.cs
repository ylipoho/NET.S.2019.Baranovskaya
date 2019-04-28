using System;
using System.Collections.Generic;
using GenericMatrix;

namespace GenericMatrix
{
    public static class ExtendedMatrix<T>
    {
        public static SquareMatrix<T> GetSum(SquareMatrix<T> first, SquareMatrix<T> second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }

            SquareMatrix<T> newMatrix;

            if (first.Size != second.Size)
            {
                throw new ArgumentException();
            }
            else
            {
                newMatrix = new SquareMatrix<T>(first.Size);

                for (int i=0; i<first.Size; i++)
                {
                    for (int j = 0; j < first.Size; j++)
                    {
                        newMatrix[i, j] = (dynamic)first[i, j] + (dynamic)second[i, j];
                    }
                }
            }

            return newMatrix;
        }
    }
}
