using System;

namespace BankingSystem
{
    // Clase abstracta: NO se puede instanciar directamente
    public abstract class Account
    {
        // Propiedades protegidas: accesibles por clases hijas
        protected string AccountNumber { get; set; }
        protected string OwnerName { get; set; }
        protected decimal Balance { get; set; }

        // Propiedad abstracta: cada hija DEBE implementarla
        public abstract string AccountTypeName { get; }

        // Constructor protegido: solo las hijas pueden llamarlo
        protected Account(string accountNumber, string ownerName, decimal initialBalance)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("El número de cuenta no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(ownerName))
                throw new ArgumentException("El nombre del titular no puede estar vacío.");

            if (initialBalance < 0)
                throw new ArgumentException("El balance inicial no puede ser negativo.");

            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Balance = initialBalance;
        }

        // Método normal: todas las cuentas depositan igual
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("ERROR: El monto a depositar debe ser mayor a 0.");
                return;
            }

            Balance += amount;
            Console.WriteLine($"Depositado {amount:C}. Nuevo balance: {Balance:C}");
        }

        // Método abstracto: cada tipo de cuenta tiene reglas diferentes
        // Las clases hijas DEBEN implementar este método
        public abstract void Withdraw(decimal amount);

        // Método abstracto: cada tipo de cuenta calcula interés diferente
        // Las clases hijas DEBEN implementar este método
        public abstract void CalculateInterest();

        // Método virtual: comportamiento por defecto que puede sobrescribirse
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Cuenta: {AccountNumber}");
            Console.WriteLine($"Titular: {OwnerName}");
            Console.WriteLine($"Tipo: {AccountTypeName}");
            Console.WriteLine($"Balance: {Balance:C}");
        }

        // Método protegido auxiliar para que las hijas obtengan el balance
        protected decimal GetBalance()
        {
            return Balance;
        }
    }
}