using labTumakov.Enums;

namespace labTumakov.Class
{
    public class BankAccount
    {
        private static int _nextAccountNumber = 1;
        private int _accountNumber;
        private decimal _balance;
        private BankAccountType _accountType;

        public int AccountNumber
        {
            get { return _accountNumber; }
        }

        public decimal Balance
        {
            get { return _balance; }
        }

        public BankAccountType AccountType
        {
            get { return _accountType; }
        }

        #region Конструктор

        /// <summary>
        /// Создаёт банковский счёт
        /// </summary>
        public BankAccount(decimal balance, BankAccountType accountType)
        {
            _accountNumber = _nextAccountNumber++;
            _balance = balance;
            _accountType = accountType;
        }

        #endregion

        #region Работа со счетом

        /// <summary>
        /// Пополняет банковский счёт
        /// </summary>
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма пополнения должна быть больше нуля");
                return;
            }

            _balance += amount;
        }

        /// <summary>
        /// Снимает деньги со счёта
        /// </summary>
        public bool Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > _balance)
            {
                Console.WriteLine("Невозможно выполнить снятие: нельзя снять сумму больше имеющейся или меньше нуля");
                return false;
            }

            _balance -= amount;
            return true;
        }

        /// <summary>
        /// Переводит деньги с другого счёта на текущий
        /// </summary>
        public bool TransferMoney(BankAccount sourceAccount, decimal amount)
        {
            if (sourceAccount == null)
            {
                Console.WriteLine("Счёт отправителя не найден");
                return false;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть больше нуля");
                return false;
            }

            if (!sourceAccount.Withdraw(amount))
                return false;

            Deposit(amount);

            Console.WriteLine("Перевод выполнен");
            return true;
        }

        #endregion

        #region Вывод информации

        /// <summary>
        /// Выводит информацию о банковском счёте
        /// </summary>
        public void PrintInformation()
        {
            Console.WriteLine($"Номер счёта: {_accountNumber}");
            Console.WriteLine($"Баланс: {_balance:F2}");
            Console.WriteLine($"Тип счёта: {_accountType}");
            Console.WriteLine();
        }

        #endregion
    }
}
