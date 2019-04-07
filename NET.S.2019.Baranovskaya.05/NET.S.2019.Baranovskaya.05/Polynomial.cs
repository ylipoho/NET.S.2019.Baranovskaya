namespace Polynomials
{
    using System;
    using System.Text;

    /// <summary>
    /// class that describes polynomial
    /// </summary>
    public sealed class Polynomial
    {
        /// <summary>
        /// Initializes a new instance of the Polynomial class.
        /// </summary>
        /// <param name="coeffs"> coefficients of current polynomial</param>
        public Polynomial(params double[] coeffs)
        {
            this.Array = new double[coeffs.Length];
            for (int i = 0; i < coeffs.Length; i++)
            {
                this.Array[i] = coeffs[i];
            }
        }
        
        /// <summary>
        /// Gets current polynomial degree
        /// </summary>
        public int Degree => this.Array.Length;

        /// <summary>
        /// Gets current polynomial coefficients
        /// </summary>
        private double[] Array { get; }

        /// <summary>
        /// Returns one of polynomial coefficient
        /// </summary>
        /// <param name="index"> polynomial degree </param>
        /// <returns> value with given coefficient </returns>
        public double this [int index]
        {
            get { return this.Array[index]; }
        }

        /// <summary>
        /// Returns given polynomial sum
        /// </summary>
        /// <param name="p1">first addend</param>
        /// <param name="p2">second addend</param>
        /// <returns>sum of two polynomials as new instance</returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            int i;
            int d1 = p1.Degree;
            int d2 = p2.Degree;
            int maxDegree = Math.Max(d1, d2);
            int differense = Math.Abs(d1 - d2);

            double[] values = new double[maxDegree];
            
            if (d1 > d2)
            {
                for (i = 0; i < differense; i++)
                {
                    values[i] = p1[i];
                }
            }
            else
            {
                for (i = 0; i < differense; i++)
                {
                    values[i] = p2[i];
                }
            }

            for (int j = i; j < p1.Degree; j++)
            {
                values[j] = p1[j] + p2[j];
            }

            return new Polynomial(values);
        }

        /// <summary>
        /// Returns given polynomial difference 
        /// </summary>
        /// <param name="p1">minuend</param>
        /// <param name="p2">subtrahend</param>
        /// <returns>difference between two polynomials as new instance</returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            int i;
            int d1 = p1.Degree;
            int d2 = p2.Degree;
            int maxDegree = Math.Max(d1, d2);
            int differense = Math.Abs(d1 - d2);

            double[] values = new double[maxDegree];

            if (d1 > d2)
            {
                for (i = 0; i < differense; i++)
                {
                    values[i] = p1[i];
                }
            }
            else
            {
                for (i = 0; i < differense; i++)
                {
                    values[i] = p2[i];
                }
            }

            for (int j = i; j < p1.Degree; j++)
            {
                values[j] = p1[j] - p2[j];
            }

            return new Polynomial(values);
        }

        /// <summary>
        /// Determines if the polynomials are equals
        /// </summary>
        /// <param name="p1">first polynomial</param>
        /// <param name="p2">second polynomial</param>
        /// <returns>true if polynomial are equals; otherwise, false</returns>
        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }

            if (p1 == null || p2 == null)
            {
                return false;
            }

            return p1.Equals(p2);
        }

        /// <summary>
        /// Determines if the polynomials are not equals
        /// </summary>
        /// <param name="p1">first polynomial</param>
        /// <param name="p2">second polynomial</param>
        /// <returns>true, if polynomials are not equals; otherwise, false</returns>
        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Returns product of given polynomial and double value
        /// </summary>
        /// <param name="p1">first multiplier</param>
        /// <param name="value">double value</param>
        /// <returns> product of given polynomial and double value as new instance</returns>
        public static Polynomial operator *(Polynomial p1, double value)
        {
            if (value == 0)
            {
                return new Polynomial();
            }

            double[] values = new double[p1.Degree];

            for (int i = 0; i < p1.Degree; i++)
            {
                values[i] = p1[i] * value;
            }

            return new Polynomial(values);
        }

        /// <summary>
        /// Returns product of given polynomial and double value
        /// </summary>
        /// <param name="value">double value</param>
        /// <param name="p1">given polynomial</param>
        /// <returns> product of given polynomial and double value as new instance</returns>
        public static Polynomial operator *(double value, Polynomial p1)
        {
            return p1 * value;
        }

        /// <summary>
        /// Returns quotient of given polynomial and double value
        /// </summary>
        /// <param name="p1">given polynomial</param>
        /// <param name="value">double value</param>
        /// <returns>quotient of given polynomial and double value as a new instance</returns>
        public static Polynomial operator /(Polynomial p1, double value)
        {
            if (value == 0)
            {
                throw new DivideByZeroException();
            }

            double[] values = new double[p1.Degree];

            for (int i = 0; i < p1.Degree; i++)
            {
                values[i] = p1[i] / value;
            }

            return new Polynomial(values);
        }

        #region object methods

        /// <summary>
        /// Returns a String representing the name of the current Polynomial
        /// </summary>
        /// <returns>A System.String representing the name of the current Polynomial</returns>
        public override string ToString()
        {
            if (this.Degree == 0)
            {
                return string.Empty;
            }

            if (this.Degree == 1)
            {
                return this[0].ToString();
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.Degree - 1; i++)
            {
                if (this[i] != 0)
                {
                    string sign;

                    if (this[i] > 0) 
                    {
                        sign = i != 0 ? "+" : string.Empty;
                        result.AppendFormat("{0}{1}x^{2}", sign, this[i], (this.Degree - i - 1).ToString());
                    }
                    else
                    {
                        result.AppendFormat("{0}x^{1}", this[i], (this.Degree - i - 1).ToString());
                    }                    
                }
            }

            string lastSign = this[this.Degree - 1] > 0 ? "+" : string.Empty;
            return result.AppendFormat("{0}{1}", lastSign, this[this.Degree - 1]).ToString();
        }

        /// <summary>
        /// Determines if the underlying system type of the current System.Type is the same
        /// as the underlying system type of the specified System.Object.
        /// </summary>
        /// <param name="obj">The object whose underlying system type is to be compared with the underlying
        /// system type of the current System.Type.</param>
        /// <returns>true if the underlying system type of o is the same as the underlying system
        /// type of the current System.Type; otherwise, false. This method also returns false
        /// if the object specified by the o parameter is not a Type.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (!this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Polynomial p = obj as Polynomial;

            if (this.Degree != p.Degree)
            {
                return false;
            }

            for (int i = 0; i < this.Degree; i++)
            {
                if (Math.Abs(this[i] - p[i]) > 0.00000001)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns the hash code for this instance
        /// </summary>
        /// <returns>The hash code for this instance</returns> 
        public override int GetHashCode()
        {
            int hash = 0;

            for (int i = 0; i < this.Degree; i++)
            {
                hash ^= this.ShiftAndWrap(this[i], 2);
            }

            return hash;
        }

        /// <summary>
        /// Additional method for GetHashCode method
        /// </summary>
        /// <param name="value">input value</param>
        /// <param name="positions">position</param>
        /// <returns>hash code</returns>
        private int ShiftAndWrap(double value, int positions)
        {
            positions = positions & 0x1F;
            
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            uint wrapped = number >> (32 - positions);
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }
        #endregion
    }
}
