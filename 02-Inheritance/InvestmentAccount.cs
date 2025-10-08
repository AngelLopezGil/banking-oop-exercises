using System;

namespace BankingSystem
{
    public class InvestmentAccount : Account
    {
        // Constantes específicas de cuenta de inversión
        private const decimal TransactionFeeRate = 0.02m;  // 2% de comisión
        private const decimal InterestRate = 0.07m;        // 7% de interés anual

        // Constructor
        public InvestmentAccount(string accountNumber, string ownerName, decimal initialBalance)
            : base(accountNumber, ownerName, initialBalance)
        {
            // Las cuentas de inversión no tienen requisitos especiales de balance inicial
        }

        // Implementación obligatoria de la propiedad abstracta
        public override string AccountTypeName => "Cuenta de Inversión";

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
            // 2. Calcular comisión: fee = amount * TransactionFeeRate
            var fee = amount * TransactionFeeRate;
            // 3. Calcular total a restar: amount + fee
            var totalRestar = amount + fee;
            // 4. Verificar que Balance >= total (no permite negativos)
            if(Balance < totalRestar)
            {
                Console.WriteLine("ERROR: Fondos insuficientes.");
                return;
            }
            // 5. Si cumple:
            //    a. Restar amount de Balance
            //    b. Restar fee de Balance
            //    c. Mostrar mensaje con amount, fee y nuevo balance
            Balance -= amount;
            Balance -= fee;
            Console.WriteLine($"Retirado {amount:C}. Comisión: {fee:C}. Nuevo balance: {Balance:C}");
        }

        // Implementación obligatoria del método abstracto
        public override void CalculateInterest()
        {
            // TODO:
            // 1. Calcular interés: Balance * InterestRate
            var interes = Balance * InterestRate;
            // 2. Sumar interés al Balance
            Balance += interes;
            // 3. Mostrar mensaje con interés aplicado y nuevo balance
            Console.WriteLine($"Interés aplicado: {interes:C}. Nuevo balance: {Balance:C}");

        }
    }
}