using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class BankAccount
    {
        enum gradation
        {
            Base,
            Gold,
            Platinum
        }

        private long number;
        private string firstName;
        private string secondName;
        private int sum;
        private double bonusScore;

        public string FullName => String.Format("{0} {1}", firstName, secondName);


    }
}
