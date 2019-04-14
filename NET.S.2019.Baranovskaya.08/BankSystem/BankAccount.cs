// <copyright file="BankAccount.cs" company="companyName">
// Copyright (c) companyName. All rights reserved.
// </copyright>
namespace BankSystem
{
    using BankSystem.Gradations;
    using System;
    using System.IO;

    /// <summary>
    /// Describes bank account
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// unique number of the account
        /// </summary>
        private int number;

        /// <summary>
        /// user first name
        /// </summary>
        private string firstName;

        /// <summary>
        /// user second name
        /// </summary>
        private string secondName;
        
        /// <summary>
        /// level of the bonus
        /// </summary>
        public int bonusScore;

        /// <summary>
        /// Stored sum of the account
        /// </summary>
        private double sum;

        /// <summary>
        /// Gets or sets status of the account
        /// </summary>
        public bool IsOpened { get; internal set; }

        /// <summary>
        /// Initializes a new instance of <see cref="BankAccount"/> class
        /// </summary>
        internal BankAccount(int number, string firstName, string secondName, Gradation accountGradation)
        {
            this.number = number;
            this.firstName = firstName;
            this.secondName = secondName;
            this.AccountGradation = accountGradation;
            this.Sum = 0;
            this.IsOpened = true;
            this.bonusScore = 0;
        }

        internal BankAccount (int number, string firstName, string secondName, Gradation accountGradation, double sum, bool isOpened, int bonusScore)
        {
            this.number = number;
            this.firstName = firstName;
            this.secondName = secondName;
            this.AccountGradation = accountGradation;
            this.Sum = sum;
            this.IsOpened = isOpened;
            this.bonusScore = bonusScore;
        }

        /// <summary>
        /// Describes account gradation and privilege
        /// </summary>
        public Gradation AccountGradation { get; private set; }

        /// <summary>
        /// Gets or sets amount of money
        /// </summary>
        public double Sum
        {
            get { return Math.Round(this.sum, 2); }
            private set { this.sum = value;  }
        }
        
        public bool Withdraw(int money)
        {
            if (this.IsOpened)
            {
                if (money  > 0)
                {
                    if (this.Sum - money < 0)
                    {
                        throw new ArgumentException("Insufficient funds.");
                    }
                    else
                    {
                        this.Sum -= money;
                        ChangeBonusScore(-money);
                        return true;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Sum cannot be less or equals to zero");
                }
            }
            else
            {
                throw new Exception("Access denied. This account is closed");
            }
        }

        public bool Deposit(int money)
        {
            if (this.IsOpened)
            { 
                this.Sum += money;
                ChangeBonusScore(money);
                return true;
            }
            else
            {
                throw new Exception("Access denied. This account is closed");
            }
        }


        private void ChangeBonusScore(int money)
        {
            if (money > 0)
            {
                this.bonusScore += AccountGradation.GetBonusScoreIncrease(money);
            }
            else
            {
                this.bonusScore += AccountGradation.GetBonusScoreDecrease(money);
            }
        }
        

        internal void WriteToFile(BinaryWriter bw)
        {
            bw.Write(this.number);
            bw.Write(this.firstName);
            bw.Write(this.secondName);
            bw.Write(this.bonusScore);
            bw.Write(this.sum);
            bw.Write(this.IsOpened);
            bw.Write(this.AccountGradation.Name);
        }
        
    }
}
