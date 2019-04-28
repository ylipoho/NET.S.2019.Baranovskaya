using System;

namespace GenericMatrix
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix() : base()
        {
        }

        public DiagonalMatrix(int size) : base(size)
        {
        }

        public DiagonalMatrix(T[] values)
        {
            this.matrix = new T[values.Length, values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                this.matrix[i, i] = values[i];
            }
        }

        public new T this[int i, int j]
        {
            get => this.matrix[i, j];

            set
            {
                if (i == j)
                {
                    this.matrix[i, j] = value;
                    this.CallDelegates(value, i, j);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
