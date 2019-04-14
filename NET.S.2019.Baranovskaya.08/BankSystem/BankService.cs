// <copyright file="BankService.cs" company="companyName">
// Copyright (c) companyName. All rights reserved.
// </copyright>
namespace BankSystem
{
    using System.Collections.Generic;
    using System.IO;
    using Gradations;

    /// <summary>
    /// Class that describes bank account list and contains method for working with accounts
    /// </summary>
    public class BankService
    {
        /// <summary>
        /// Contains bank accounts
        /// </summary>
        private List<BankAccount> bankAccounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankService"/> class 
        /// </summary>
        public BankService()
        {
            this.bankAccounts = new List<BankAccount>();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BankAccount"/> class and adds it to account list
        /// </summary>
        /// <param name="firstName">user first name</param>
        /// <param name="secondName">user second name</param>
        /// <param name="gradation">account gradation</param>
        /// <returns>bank account</returns>
        public BankAccount CreateAccount(string firstName, string secondName, Gradation gradation)
        {
            int number = this.bankAccounts.Count + 1;
            BankAccount bankAccount = new BankAccount(number, firstName, secondName, gradation);
            this.bankAccounts.Add(bankAccount);
            return bankAccount;
        }

        /// <summary>
        /// Closes bank account and delete it from account list
        /// </summary>
        /// <param name="bankAccount">bank account</param>
        /// <returns>true if successfully</returns>
        public bool CloseAccount(BankAccount bankAccount)
        {
            for (int i = 0; i < this.bankAccounts.Count; i++)
            {
                if (bankAccount.Equals(this.bankAccounts[i]))
                {
                    this.bankAccounts[i].IsOpened = false;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Initializes a BookListStorage property from binary file
        /// </summary>
        /// <param name="path">file path</param>
        public void LoadBankAccountsListStorageFromBinaryFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    // bookListStorage.Clear();
                    while (br.PeekChar() > -1)
                    {
                        int number = br.ReadInt32();                        
                        string firstName = br.ReadString();
                        string secondName = br.ReadString();
                        int bonusScore = br.ReadInt32();
                        double sum = br.ReadDouble();
                        bool isOpened = br.ReadBoolean();
                        string gradationName = br.ReadString();
                        
                        Gradation gradation = null;

                        switch (gradationName)
                        {
                            case "Base":
                                gradation = new BaseGradation();
                                break;
                            case "Gold":
                                gradation = new GoldGradation();
                                break;
                            case "Platinum":
                                gradation = new PlatinumGradation();
                                break;
                        }

                        this.bankAccounts.Add(new BankAccount(number, firstName, secondName, gradation, sum, isOpened, bonusScore));
                    }
                }
            }
        }

        /// <summary>
        /// Save a BookListStorage to binary file
        /// </summary>
        /// <param name="path">file path</param>
        public void SaveBankAccountsListToBinaryFile(string path)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (BankAccount account in this.bankAccounts)
                {
                    account.WriteToFile(bw);
                }
            }
        }
    }
}
