namespace Tests
{
    using System;
    using System.Collections.Generic;

    public class Comparators : IComparer<int>, IComparer<double>, IComparer<string>
    {
        int IComparer<int>.Compare(int x, int y)
        {
            return x - y;
        }

        int IComparer<double>.Compare(double x, double y)
        {
            return x.CompareTo(y);
        }

        int IComparer<string>.Compare(string x, string y)
        {
            return x.CompareTo(y);
        }
    }
}
