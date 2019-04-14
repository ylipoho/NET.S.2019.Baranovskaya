namespace BankSystem
{
    using System.Collections.Generic;
    using System.IO;
    using Gradations;

    public class BankService
    {

        List<BankAccount> bankAccounts;

        public BankService()
        {
            bankAccounts = new List<BankAccount>();
        }

        public BankAccount CreateAccount(string firstName, string secondName, Gradation gradation)
        {
            int number = bankAccounts.Count + 1;
            BankAccount bankAccount = new BankAccount(number, firstName, secondName, gradation);
            bankAccounts.Add(bankAccount);
            return bankAccount;
        }

        public bool CloseAccount(BankAccount bankAccount)
        {
            for (int i=0; i< bankAccounts.Count; i++)
            {
                if (bankAccount.Equals(bankAccounts[i]))
                {
                    bankAccounts[i].IsOpened = false;
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
