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
        
        public SquareMatrix()
        {
            this.matrix = new T[DefaultSize, DefaultSize];
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

        public delegate void MatrixDelegate(T value, int i, int j);

        public event MatrixDelegate MatrixEvent;

        public int Size => matrix.GetLength(0);
        
        protected int DefaultSize => 2;

        public T this[int i, int j]
        {
            get => this.matrix[i, j];

            set
            {
                this.matrix[i, j] = value;
                this.CallDelegates(value, i, j);
            }
        }

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