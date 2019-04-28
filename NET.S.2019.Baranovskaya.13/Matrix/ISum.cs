using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    interface ISum<T> where T: struct 
    {
        Matrix<T> GetSum(Matrix<T> other, IComparer<T> comparer);

        /*public T[,] GetSum(T[,] other, IComparer<T> comparer)
        {
            if (this.matrix.Rank != other.Rank)
            {
                throw new ArgumentException("matrix should have the same size");
            }

            T[,] result = new T[this.matrix.Rank, this.matrix.Rank];

            for (int i = 0; i < this.matrix.Rank; i++)
            {
                for (int j = 0; j < this.matrix.Rank; j++)
                {
                    result[i, j] = (dynamic)this.matrix[i, j] + (dynamic)this.matrix[i, j];
                }

            }

            return result;
        }*/
    }
}
