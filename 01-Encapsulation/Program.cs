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
            cuenta.DisplayInfo();

            // AQUÍ debes escribir código que demuestre los PROBLEMAS
            // Intenta hacer cosas que NO deberían ser posibles
            // Documenta cada problema que encuentres
            BankAccount cuenta2 = new BankAccount(12345, "Juan Perez", 1000m);

            cuenta.balance = 2000m;
            cuenta.accountNumber = "1234599";
            cuenta.DisplayInfo();

            cuenta2.balance = 3000m;
            cuenta2.accountNumber = "999";
            cuenta2.DisplayInfo();

            Console.ReadKey();
        }
    }
}