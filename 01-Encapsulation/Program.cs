using System;

namespace BankingOOP.Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Test de BankAccount ===");

            // Crea una cuenta
            BankAccount cuenta = new BankAccount("12345", "Juan Perez", 1000m);

            cuenta.Deposit(500m);
            cuenta.DisplayInfo();

            Console.ReadKey();
        }
    }
}