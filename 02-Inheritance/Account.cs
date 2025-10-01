using System;

namespace BankingSystem
{
    // Clase base para cuentas bancarias - INTENCIONALMENTE MAL DISEÑADA
    public class Account
    {
        // PROBLEMA: Campos públicos exponen el estado interno
        public string AccountNumber;
        public string OwnerName;
        public decimal Balance;
        public string AccountType;  // PROBLEMA: String para tipos es frágil

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

        // PROBLEMA: Este método tiene demasiadas responsabilidades
        public void Withdraw(decimal amount)
        {
            // PROBLEMA: Lógica específica de cada tipo mezclada con condicionales
            if (AccountType == "Savings")
            {
                if (Balance - amount >= 100)
                {
                    Balance -= amount;
                    Console.WriteLine($"Retirado {amount}. Nuevo balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Fondos insuficientes. Las cuentas de ahorro deben mantener un balance mínimo de 100.");
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
                    Console.WriteLine("Fondos insuficientes. No se puede exceder el límite de sobregiro de 500.");
                }
            }
            else if (AccountType == "Investment")
            {
                if (Balance - amount >= 0)
                {
                    Balance -= amount;
                    decimal fee = amount * 0.02m;  // Comisión del 2%
                    Balance -= fee;
                    Console.WriteLine($"Retirado {amount}. Comisión de transacción: {fee}. Nuevo balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Fondos insuficientes. Las cuentas de inversión no pueden tener balance negativo.");
                }
            }
        }

        // PROBLEMA: Más condicionales basados en strings
        public void CalculateInterest()
        {
            if (AccountType == "Savings")
            {
                decimal interest = Balance * 0.03m;  // 3% para ahorro
                Balance += interest;
                Console.WriteLine($"Interés aplicado: {interest}. Nuevo balance: {Balance}");
            }
            else if (AccountType == "Investment")
            {
                decimal interest = Balance * 0.07m;  // 7% para inversión
                Balance += interest;
                Console.WriteLine($"Interés aplicado: {interest}. Nuevo balance: {Balance}");
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