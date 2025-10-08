using System;

namespace BankingSystem
{
    public class SavingsAccount : Account
    {
        // Constante específica de cuenta de ahorro
        private const decimal MinimumBalance = 100m;
        private const decimal InterestRate = 0.03m;  // 3%

        // Constructor: llama al constructor de la clase base
        public SavingsAccount(string accountNumber, string ownerName, decimal initialBalance)
            : base(accountNumber, ownerName, initialBalance)
        {
            // Validación específica de Savings
            if (initialBalance < MinimumBalance)
                throw new ArgumentException($"Las cuentas de ahorro requieren un balance mínimo de {MinimumBalance:C}");
        }

        // Implementación obligatoria de la propiedad abstracta
        public override string AccountTypeName => "Cuenta de Ahorro";

        // Implementación obligatoria del método abstracto
        public override void Withdraw(decimal amount)
        {
            // 1. Validar amount > 0
            if (amount <= 0)
            {
                Console.WriteLine("ERROR: El monto debe ser mayor a 0.");
                return;
            }

            // 2. Verificar que Balance - amount >= MinimumBalance
            if (Balance - amount < MinimumBalance)
            {
                Console.WriteLine($"Fondos insuficientes. Las cuentas de ahorro deben mantener un balance mínimo de {MinimumBalance:C}");
                return;
            }

            // 3. Si cumple: restar amount de Balance
            Balance -= amount;

            // 4. Mostrar mensaje apropiado
            Console.WriteLine($"Retirado {amount:C}. Nuevo balance: {Balance:C}");
        }

        public override void CalculateInterest()
        {
            // 1. Calcular interés: Balance * InterestRate
            decimal intereses = Balance * InterestRate;

            // 2. Sumar interés al Balance
            Balance += intereses; 

            // 3. Mostrar mensaje
            Console.WriteLine($"Interés aplicado: {intereses:C}. Nuevo balance: {Balance:C}");
        }
    }
}