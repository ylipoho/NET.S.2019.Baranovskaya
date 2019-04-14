// <copyright file="Gradation.cs" company="companyName">
// Copyright (c) companyName. All rights reserved.
// </copyright>
namespace BankSystem
{
    /// <summary>
    /// Abstract class that describes gradation of the bank account
    /// </summary>
    public abstract class Gradation
    {
        /// <summary>
        /// Gets string representation of the gradation name
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets cost of the withdrawing
        /// </summary>
        public abstract int WithdrawCost { get; }

        /// <summary>
        /// Gets cost of the depositing
        /// </summary>
        public abstract int DepositCost { get; }

        /// <summary>
        /// Calculates bonus score size after making a deposit
        /// </summary>
        /// <param name="money">money amount</param>
        /// <returns>bonus score size</returns>
        public abstract int GetBonusScoreIncrease(int money);

        /// <summary>
        /// Calculates bonus score size after withdrawing 
        /// </summary>
        /// <param name="money">money amount</param>
        /// <returns>bonus score size</returns>
        public abstract int GetBonusScoreDecrease(int money);
    }
}
