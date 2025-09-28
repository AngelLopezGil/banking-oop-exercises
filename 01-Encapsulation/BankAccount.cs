using System;

namespace BankingOOP.Encapsulation
{
    public class BankAccount
    {
        public string accountNumber;
        public decimal balance;
        public string ownerName;
        public DateTime creationDate;
        public bool isActive;
        
        public BankAccount(string number, string owner, decimal initialBalance)
        {
            accountNumber = number;
            ownerName = owner;
            balance = initialBalance;
            creationDate = DateTime.Now;
            isActive = true;
        }
        
        public void DisplayInfo()
        {
            Console.WriteLine($"Cuenta: {accountNumber}, Propietario: {ownerName}, Saldo: {balance}");
        }
    }
}