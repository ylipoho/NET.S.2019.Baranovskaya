using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    public class SquareMatrix<T>
    {
        protected T[,] matrix;
        protected int defaultSize = 2;

        public SquareMatrix()
        {
            this.matrix = new T[defaultSize, defaultSize];
        }

        public SquareMatrix(int size)
        {
            this.matrix = new T[size, size];
        }

        public SquareMatrix(T[,] values)
        {
            this.matrix = new T[values.Rank, values.Rank];
            matrix = values;
        }

        public int Size => matrix.GetLength(0);

        public T this[int i, int j]
        {
            get => matrix[i, j];

            set
            {
                matrix[i, j] = value;
                CallDelegates(value, i, j);
            }
        }

        public delegate void matrixDelegate(T value, int i, int j);

        public event matrixDelegate MatrixEvent;

        public void CallDelegates(T value, int i, int j)
        {
            MatrixEvent?.Invoke(value, i, j);
        }

        public void Method(T value, int i, int j)
        {
            Console.WriteLine(string.Format("new value: [{0}, {1}] = {2}", value, i, j));
        }

            
    }
}
