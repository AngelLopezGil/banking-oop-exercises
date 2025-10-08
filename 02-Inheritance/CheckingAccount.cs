using System;

namespace BankingSystem
{
    public class CheckingAccount : Account
    {
        // Constantes específicas de cuenta corriente
        private const decimal OverdraftLimit = -500m;
        private const decimal OverdraftFee = 25m;

        // Constructor
        public CheckingAccount(string accountNumber, string ownerName, decimal initialBalance)
            : base(accountNumber, ownerName, initialBalance)
        {
            // Las cuentas corrientes no tienen requisitos especiales de balance inicial
        }

        // Implementación obligatoria de la propiedad abstracta
        public override string AccountTypeName => "Cuenta Corriente";

        // Implementación obligatoria del método abstracto
        public override void Withdraw(decimal amount)
        {
            // TODO:
            // 1. Validar amount > 0
            if (amount <= 0)
            {
                Console.WriteLine("ERROR: El monto debe ser mayor a 0.");
                return;
            }

            // 2. Verificar que Balance - amount >= OverdraftLimit (-500)
            if (Balance - amount < OverdraftLimit)
            {
                Console.WriteLine($"Excede límite de sobregiro");
                return;
            }
            // 3. Si cumple:
            //    a. Restar amount de Balance
            //    b. Si Balance < 0 (quedó en sobregiro):
            //       - Restar OverdraftFee adicional
            //       - Mostrar mensaje de sobregiro
            //    c. Si Balance >= 0:
            //       - Mostrar mensaje normal

            Balance -= amount;
            if (Balance < 0)
            {
                Balance -= OverdraftFee;
                Console.WriteLine($"Retirado {amount:C}. Cargo por sobregiro aplicado. Nuevo balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine($"Retirado {amount:C}. Nuevo balance: {Balance:C}");
            }
        }

        // Implementación obligatoria del método abstracto
        public override void CalculateInterest()
        {
            // Las cuentas corrientes NO generan intereses
            Console.WriteLine("Las cuentas corrientes no generan intereses.");
        }
    }
}