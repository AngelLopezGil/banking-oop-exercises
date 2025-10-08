using System;

namespace BankingSystem
{
    public class SavingsAccount : Account
    {
        // Constante espec�fica de cuenta de ahorro
        private const decimal MinimumBalance = 100m;
        private const decimal InterestRate = 0.03m;  // 3%

        // Constructor: llama al constructor de la clase base
        public SavingsAccount(string accountNumber, string ownerName, decimal initialBalance)
            : base(accountNumber, ownerName, initialBalance)
        {
            // Validaci�n espec�fica de Savings
            if (initialBalance < MinimumBalance)
                throw new ArgumentException($"Las cuentas de ahorro requieren un balance m�nimo de {MinimumBalance:C}");
        }

        // Implementaci�n obligatoria de la propiedad abstracta
        public override string AccountTypeName => "Cuenta de Ahorro";

        // Implementaci�n obligatoria del m�todo abstracto
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
                Console.WriteLine($"Fondos insuficientes. Las cuentas de ahorro deben mantener un balance m�nimo de {MinimumBalance:C}");
                return;
            }

            // 3. Si cumple: restar amount de Balance
            Balance -= amount;

            // 4. Mostrar mensaje apropiado
            Console.WriteLine($"Retirado {amount:C}. Nuevo balance: {Balance:C}");
        }

        public override void CalculateInterest()
        {
            // 1. Calcular inter�s: Balance * InterestRate
            decimal intereses = Balance * InterestRate;

            // 2. Sumar inter�s al Balance
            Balance += intereses; 

            // 3. Mostrar mensaje
            Console.WriteLine($"Inter�s aplicado: {intereses:C}. Nuevo balance: {Balance:C}");
        }
    }
}