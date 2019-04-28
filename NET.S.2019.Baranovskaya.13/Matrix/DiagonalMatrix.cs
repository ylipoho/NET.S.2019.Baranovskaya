using System;

namespace GenericMatrix
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(): base()
        {
        }

        public DiagonalMatrix(int size) : base (size)
        {
        }

        public DiagonalMatrix(T[] values)
        {
            this.matrix = new T[values.Length, values.Length];

            for (int i =0; i< values.Length; i++)
            {
                matrix[i, i] = values[i];
            }
        }

        public new T this[int i, int j]
        {
            get => matrix[i, j];

            set
            {
                if (i == j)
                {
                    matrix[i, j] = value;
                    CallDelegates(value, i, j);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
