// <copyright file="PlatinumGradation.cs" company="companyName">
// Copyright (c) companyName. All rights reserved.
// </copyright>
namespace BankSystem.Gradations
{
    /// <summary>
    /// Class that describes platinum gradation of the bank account
    /// </summary>
    public class PlatinumGradation : Gradation
    {
        /// <summary>
        /// Gets cost of the withdrawing
        /// </summary>
        public override int WithdrawCost => 25;

        /// <summary>
        /// Gets cost of the depositing
        /// </summary>
        public override int DepositCost => 2;

        /// <summary>
        /// Gets string representation of the gradation name
        /// </summary>
        public override string Name => "Platinum";

        /// <summary>
        /// Calculates bonus score size after withdrawing 
        /// </summary>
        /// <param name="money">money amount</param>
        /// <returns>bonus score size</returns>
        public override int GetBonusScoreDecrease(int money)
        {
             return this.WithdrawCost;
        }

        /// <summary>
        /// Calculates bonus score size after making a deposit
        /// </summary>
        /// <param name="money">money amount</param>
        /// <returns>bonus score size</returns>
        public override int GetBonusScoreIncrease(int money)
        {
            return (this.DepositCost * money) + 15;
        }
    }
}
