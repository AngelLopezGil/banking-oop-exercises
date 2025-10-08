using System;

namespace BankingSystem
{
    public class InvestmentAccount : Account
    {
        // Constantes espec�ficas de cuenta de inversi�n
        private const decimal TransactionFeeRate = 0.02m;  // 2% de comisi�n
        private const decimal InterestRate = 0.07m;        // 7% de inter�s anual

        // Constructor
        public InvestmentAccount(string accountNumber, string ownerName, decimal initialBalance)
            : base(accountNumber, ownerName, initialBalance)
        {
            // Las cuentas de inversi�n no tienen requisitos especiales de balance inicial
        }

        // Implementaci�n obligatoria de la propiedad abstracta
        public override string AccountTypeName => "Cuenta de Inversi�n";

        // Implementaci�n obligatoria del m�todo abstracto
        public override void Withdraw(decimal amount)
        {
            // TODO:
            // 1. Validar amount > 0
            if (amount <= 0)
            {
                Console.WriteLine("ERROR: El monto debe ser mayor a 0.");
                return;
            }
            // 2. Calcular comisi�n: fee = amount * TransactionFeeRate
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
            Console.WriteLine($"Retirado {amount:C}. Comisi�n: {fee:C}. Nuevo balance: {Balance:C}");
        }

        // Implementaci�n obligatoria del m�todo abstracto
        public override void CalculateInterest()
        {
            // TODO:
            // 1. Calcular inter�s: Balance * InterestRate
            var interes = Balance * InterestRate;
            // 2. Sumar inter�s al Balance
            Balance += interes;
            // 3. Mostrar mensaje con inter�s aplicado y nuevo balance
            Console.WriteLine($"Inter�s aplicado: {interes:C}. Nuevo balance: {Balance:C}");

        }
    }
}