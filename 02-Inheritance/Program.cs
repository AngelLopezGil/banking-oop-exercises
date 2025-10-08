using System;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema Bancario - Ejercicio de Herencia ===");
            Console.WriteLine("=== Versión Refactorizada con POO ===\n");

            // Crear cuentas usando las clases específicas
            Account savings = new SavingsAccount("SAV001", "Juan Pérez", 1000);
            Account checking = new CheckingAccount("CHK001", "María García", 500);
            Account investment = new InvestmentAccount("INV001", "Carlos López", 5000);

            // Probar cuenta de ahorros
            Console.WriteLine("=== CUENTA DE AHORRO ===");
            savings.DisplayInfo();
            savings.Deposit(200);
            savings.Withdraw(50);
            savings.CalculateInterest();

            // Probar cuenta corriente con sobregiro
            Console.WriteLine("\n=== CUENTA CORRIENTE ===");
            checking.DisplayInfo();
            checking.Deposit(100);
            checking.Withdraw(700);  // Provocará sobregiro y cargo de fee
            checking.CalculateInterest();

            // Probar cuenta de inversión
            Console.WriteLine("\n=== CUENTA DE INVERSIÓN ===");
            investment.DisplayInfo();
            investment.Withdraw(1000);  // Aplicará comisión del 2%
            investment.CalculateInterest();

            // Demostrar validaciones
            Console.WriteLine("\n=== PRUEBAS DE VALIDACIÓN ===");

            Console.WriteLine("\n--- Intento de retiro que excede balance mínimo en Savings ---");
            savings.Withdraw(1200);  // Debe rechazarse (balance mínimo 100)

            Console.WriteLine("\n--- Intento de retiro que excede límite de sobregiro en Checking ---");
            checking.Withdraw(1000);  // Debe rechazarse (límite -500)

            Console.WriteLine("\n--- Intento de retiro con monto negativo ---");
            investment.Withdraw(-50);  // Debe rechazarse

            Console.WriteLine("\n--- Intento de depósito con monto 0 ---");
            savings.Deposit(0);  // Debe rechazarse

            // Demostrar polimorfismo
            Console.WriteLine("\n=== DEMOSTRACIÓN DE POLIMORFISMO ===");
            Account[] allAccounts = { savings, checking, investment };

            Console.WriteLine("\nAplicando intereses a todas las cuentas:");
            foreach (Account account in allAccounts)
            {
                Console.WriteLine($"\n{account.AccountTypeName}:");
                account.CalculateInterest();
            }

            Console.WriteLine("\n=== FIN DEL PROGRAMA ===");
        }
    }
}