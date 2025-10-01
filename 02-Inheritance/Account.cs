using System;

namespace BankingSystem
{
    // Clase base para cuentas bancarias - INTENCIONALMENTE MAL DISE�ADA
    public class Account
    {
        // PROBLEMA: Campos p�blicos exponen el estado interno
        public string AccountNumber;
        public string OwnerName;
        public decimal Balance;
        public string AccountType;  // PROBLEMA: String para tipos es fr�gil

        public Account(string accountNumber, string ownerName, decimal initialBalance, string accountType)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Balance = initialBalance;
            AccountType = accountType;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Depositado {amount}. Nuevo balance: {Balance}");
        }

        // PROBLEMA: Este m�todo tiene demasiadas responsabilidades
        public void Withdraw(decimal amount)
        {
            // PROBLEMA: L�gica espec�fica de cada tipo mezclada con condicionales
            if (AccountType == "Savings")
            {
                if (Balance - amount >= 100)
                {
                    Balance -= amount;
                    Console.WriteLine($"Retirado {amount}. Nuevo balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Fondos insuficientes. Las cuentas de ahorro deben mantener un balance m�nimo de 100.");
                }
            }
            else if (AccountType == "Checking")
            {
                if (Balance - amount >= -500)
                {
                    Balance -= amount;
                    if (Balance < 0)
                    {
                        Balance -= 25;  // Cargo por sobregiro
                        Console.WriteLine($"Retirado {amount}. Cargo por sobregiro aplicado. Nuevo balance: {Balance}");
                    }
                    else
                    {
                        Console.WriteLine($"Retirado {amount}. Nuevo balance: {Balance}");
                    }
                }
                else
                {
                    Console.WriteLine("Fondos insuficientes. No se puede exceder el l�mite de sobregiro de 500.");
                }
            }
            else if (AccountType == "Investment")
            {
                if (Balance - amount >= 0)
                {
                    Balance -= amount;
                    decimal fee = amount * 0.02m;  // Comisi�n del 2%
                    Balance -= fee;
                    Console.WriteLine($"Retirado {amount}. Comisi�n de transacci�n: {fee}. Nuevo balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Fondos insuficientes. Las cuentas de inversi�n no pueden tener balance negativo.");
                }
            }
        }

        // PROBLEMA: M�s condicionales basados en strings
        public void CalculateInterest()
        {
            if (AccountType == "Savings")
            {
                decimal interest = Balance * 0.03m;  // 3% para ahorro
                Balance += interest;
                Console.WriteLine($"Inter�s aplicado: {interest}. Nuevo balance: {Balance}");
            }
            else if (AccountType == "Investment")
            {
                decimal interest = Balance * 0.07m;  // 7% para inversi�n
                Balance += interest;
                Console.WriteLine($"Inter�s aplicado: {interest}. Nuevo balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Este tipo de cuenta no genera intereses.");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Cuenta: {AccountNumber}");
            Console.WriteLine($"Titular: {OwnerName}");
            Console.WriteLine($"Tipo: {AccountType}");
            Console.WriteLine($"Balance: {Balance}");
        }
    }
}