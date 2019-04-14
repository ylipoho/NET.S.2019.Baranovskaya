namespace BankAccountConsoleApplication
{
    using System;
    using BankSystem;
    using BankSystem.Gradations;

    class Program
    {
        static void Main(string[] args)
        {
            BankService bankService = new BankService();
            BankAccount account1 = bankService.CreateAccount("John", "Smith", new GoldGradation());
            
            Console.WriteLine("Try to withdraw 120...");

            try
            {
                account1.Withdraw(120);
                Console.WriteLine("-120: Successfully");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            
            account1.Deposit(200);

            Console.WriteLine("+200: Successfully");

            try
            {
                account1.Withdraw(120);
                Console.WriteLine("-120: Successfully");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            
            bankService.SaveBankAccountsListToBinaryFile(@"C:\Users\admin\Documents\GitHub\NET.S.2019.Baranovskaya\NET.S.2019.Baranovskaya.08\accounts.bin");

            BankService banksService2 = new BankService();
            banksService2.LoadBankAccountsListStorageFromBinaryFile(@"C:\Users\admin\Documents\GitHub\NET.S.2019.Baranovskaya\NET.S.2019.Baranovskaya.08\accounts.bin");

            Console.ReadKey();
        }
    }
}
