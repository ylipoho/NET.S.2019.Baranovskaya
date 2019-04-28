using System;

namespace GenericMatrix
{
    public class SymmetricalMatrix<T> : SquareMatrix<T>
    {
        public SymmetricalMatrix() : base()
        {
        }

        public SymmetricalMatrix(int size) : base(size)
        {
        }

        public SymmetricalMatrix(T[,] values)
        {
            this.matrix = new T[values.Rank, values.Rank];
            
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = i + 1; j < values.GetLength(0); j++)
                {
                    if (!values[i, j].Equals(values[j, i]))
                    {
                        throw new ArgumentException();
                    }
                }
            }

            this.matrix = values;
        }

        public new T this[int i, int j]
        {
            get => this.matrix[i, j];

            set
            {
                this.matrix[i, j] = value;
                this.CallDelegates(value, i, j);

                if (i != j)
                {
                    this.matrix[j, i] = value;
                    this.CallDelegates(value, j, i);
                }
            }
        }
    }
}
