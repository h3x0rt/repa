using System;

namespace ConsoleApp9
{


    class ATM
    {
        private decimal balance;

        public ATM(decimal initialBalance)
        {
            balance = initialBalance;
        }

        public void ShowBalance()
        {
            Console.WriteLine($"\nВаш текущий баланс: {balance} руб.");
        }

        public void WithdrawMoney()
        {
            Console.Write("\nВведите сумму для снятия: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                if (amount <= 0)
                {
                    Console.WriteLine("\nСумма должна быть положительным числом.");
                }
                else if (amount > balance)
                {
                    Console.WriteLine("\nНедостаточно средств на счёте.");
                }
                else
                {
                    balance -= amount;
                    Console.WriteLine($"\nВы успешно сняли {amount} руб. Остаток: {balance} руб.");
                }
            }
            else
            {
                Console.WriteLine("\nОшибка ввода. Пожалуйста, введите числовое значение.");
            }
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\nДобро пожаловать в банкомат!");
                Console.WriteLine("1. Показать баланс");
                Console.WriteLine("2. Снять деньги");
                Console.WriteLine("3. Выход");

                Console.Write("\nВыберите действие (1-3): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowBalance();
                        break;
                    case "2":
                        WithdrawMoney();
                        break;
                    case "3":
                        Console.WriteLine("\nСпасибо за использование банкомата. До свидания!");
                        return;
                    default:
                        Console.WriteLine("\nНеверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            ATM atm = new ATM(initialBalance: 1000); // Устанавливаем начальный баланс
            atm.Start();
            Console.WriteLine("\nНажмите любую клавишу, чтобы выйти...");
            Console.ReadKey(); // Ожидание нажатия клавиши
        }
    }
}
