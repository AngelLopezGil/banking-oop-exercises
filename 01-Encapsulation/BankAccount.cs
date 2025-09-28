using System;

namespace BankingOOP.Encapsulation
{
    public class BankAccount
    {
        private string _accountNumber;
        private decimal _balance;
        private string _ownerName;
        private DateTime _creationDate;
        private bool _isActive;

        public BankAccount(string number, string owner, decimal initialBalance)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Número de cuenta no puede estar vacio");

            if (string.IsNullOrWhiteSpace(owner))
                throw new ArgumentException("Nombre del propietario requerido");

            if (initialBalance < 0)
                throw new ArgumentException("Balance inicial no puede ser negativo");

            _accountNumber = number;
            _ownerName = owner;
            _balance = initialBalance;
            _creationDate = DateTime.Now;
            _isActive = true;
        }

        // Propiedades de solo lectura
        public string AccountNumber => _accountNumber;
        public decimal Balance => _balance;
        public string OwnerName => _ownerName;
        public DateTime CreationDate => _creationDate;

        // Propiedad con validación
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (!value && _balance > 0)
                    throw new InvalidOperationException("No se puede desactivar cuenta con saldo positivo");
                _isActive = value;
            }
        }

        public bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Cantidad debe ser positiva");
                return false;
            }

            if (!_isActive)
            {
                Console.WriteLine("Cuenta inactiva");
                return false;
            }

            _balance += amount;
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Cantidad debe ser positiva");
                return false;
            }

            if (!_isActive)
            {
                Console.WriteLine("Cuenta inactiva");
                return false;
            }

            if (amount > _balance)
            {
                Console.WriteLine("Fondos insuficientes");
                return false;
            }

            _balance -= amount;
            return true;
        }
        
        public void DisplayInfo()
    {
        Console.WriteLine($"Cuenta: {AccountNumber}, Propietario: {OwnerName}, Saldo: {Balance:C}");
    }
    }
}