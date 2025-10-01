using System;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema Bancario - Ejercicio de Herencia ===\n");

            // Crear cuentas de diferentes tipos usando la clase Account única
            Account savings = new Account("SAV001", "Juan Pérez", 1000, "Savings");
            Account checking = new Account("CHK001", "María García", 500, "Checking");
            Account investment = new Account("INV001", "Carlos López", 5000, "Investment");

            // Probar cuenta de ahorros
            Console.WriteLine("=== CUENTA DE AHORRO ===");
            savings.DisplayInfo();
            savings.Deposit(200);
            savings.Withdraw(50);
            savings.CalculateInterest();

            Console.WriteLine("\n=== CUENTA CORRIENTE ===");
            checking.DisplayInfo();
            checking.Withdraw(600);  // Provocará sobregiro
            checking.CalculateInterest();

            Console.WriteLine("\n=== CUENTA DE INVERSIÓN ===");
            investment.DisplayInfo();
            investment.Withdraw(1000);  // Aplicará comisión
            investment.CalculateInterest();

            // CASO PROBLEMÁTICO: ¿Qué pasa si hay un typo en el tipo?
            Console.WriteLine("\n=== CASO PROBLEMÁTICO ===");
            Account broken = new Account("BRK001", "Usuario Error", 1000, "Savingss");  // Typo intencional
            broken.DisplayInfo();
            broken.Withdraw(100);  // ¿Qué comportamiento tendrá?
            broken.CalculateInterest();

            // OTRO CASO PROBLEMÁTICO: Tipo inexistente
            Console.WriteLine("\n=== OTRO CASO PROBLEMÁTICO ===");
            Account premium = new Account("PRM001", "Cliente Premium", 10000, "Premium");
            premium.DisplayInfo();
            premium.Withdraw(500);
            premium.CalculateInterest();
        }
    }
}