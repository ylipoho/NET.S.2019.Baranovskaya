// <copyright file="GoldGradation.cs" company="companyName">
// Copyright (c) companyName. All rights reserved.
// </copyright>
namespace BankSystem.Gradations
{
    /// <summary>
    /// Class that describes gold gradation of the bank account
    /// </summary>
    public class GoldGradation : Gradation
    {
        /// <summary>
        /// Gets cost of the withdrawing
        /// </summary>
        public override int WithdrawCost => 5;

        /// <summary>
        /// Gets cost of the depositing
        /// </summary>
        public override int DepositCost => 5;

        /// <summary>
        /// Gets string representation of the gradation name
        /// </summary>
        public override string Name => "Gold";

        /// <summary>
        /// Calculates bonus score size after withdrawing 
        /// </summary>
        /// <param name="money">money amount</param>
        /// <returns>bonus score size</returns>
        public override int GetBonusScoreDecrease(int money)
        {
            return this.WithdrawCost * money / 100;
        }

        /// <summary>
        /// Calculates bonus score size after making a deposit
        /// </summary>
        /// <param name="money">money amount</param>
        /// <returns>bonus score size</returns>
        public override int GetBonusScoreIncrease(int money)
        {
            return (this.DepositCost * money)  + 20;
        }
    }
}
