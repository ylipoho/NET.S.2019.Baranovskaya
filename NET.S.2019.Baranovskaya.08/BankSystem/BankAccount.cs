// <copyright file="BankAccount.cs" company="companyName">
// Copyright (c) companyName. All rights reserved.
// </copyright>
namespace BankSystem
{
    using System;
    using System.IO;

    /// <summary>
    /// Describes bank account
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// level of the bonus
        /// </summary>
        private int bonusScore;

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
        /// Stored sum of the account
        /// </summary>
        private double sum;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class
        /// </summary>
        /// <param name="number">unique number</param>
        /// <param name="firstName">user first name</param>
        /// <param name="secondName">user second name</param>
        /// <param name="accountGradation">account gradation</param>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class
        /// </summary>
        /// <param name="number">unique number</param>
        /// <param name="firstName">user first name</param>
        /// <param name="secondName">user second name</param>
        /// <param name="accountGradation">account gradation</param>
        /// <param name="sum">money amount</param>
        /// <param name="isOpened">account status</param>
        /// <param name="bonusScore">bonus score</param>
        internal BankAccount(int number, string firstName, string secondName, Gradation accountGradation, double sum, bool isOpened, int bonusScore)
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
        /// Gets a value indicating whether the account is opened
        /// </summary>
        public bool IsOpened { get; internal set; }

        /// <summary>
        /// Gets account gradation and privilege
        /// </summary>
        public Gradation AccountGradation { get; private set; }

        /// <summary>
        /// Gets amount of money
        /// </summary>
        public double Sum
        {
            get { return Math.Round(this.sum, 2); }
            private set { this.sum = value;  }
        }
        
        /// <summary>
        /// Withdraws given amount of money from the bank account
        /// </summary>
        /// <param name="money">money amount</param>
        /// <returns>true if successfully; otherwise, false</returns>
        /// <exception cref="ArgumentException">if money is less than zero</exception>
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
                        this.ChangeBonusScore(-money);
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

        /// <summary>
        /// Deposits given sum from the account
        /// </summary>
        /// <param name="money">money amount</param>
        /// <returns>true if successfully</returns>
        public bool Deposit(int money)
        {
            if (this.IsOpened)
            { 
                this.Sum += money;
                this.ChangeBonusScore(money);
                return true;
            }
            else
            {
                throw new Exception("Access denied. This account is closed");
            }
        }

        /// <summary>
        /// Writes account list to binary file
        /// </summary>
        /// <param name="bw">binary writer</param>
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

        /// <summary>
        /// Changes account bonus score
        /// </summary>
        /// <param name="money">money amount</param>
        private void ChangeBonusScore(int money)
        {
            if (money > 0)
            {
                this.bonusScore += this.AccountGradation.GetBonusScoreIncrease(money);
            }
            else
            {
                this.bonusScore += this.AccountGradation.GetBonusScoreDecrease(money);
            }
        }
    }
}
