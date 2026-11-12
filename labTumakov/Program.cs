using labTumakov.Class;
using labTumakov.Enums;

namespace labTumakov
{
    internal class Program
    {
        static void Main()
        {
            Task8_1();
            Task8_2();
            Task8_3();
            Task8_4();
            DZ8_1();
            DZ8_2();
        }

        #region Упражнение 8.1
        static void Task8_1()
        {
            Console.WriteLine("Упражнение 8.1");

            decimal firstBalance = ReadNonNegativeDecimal("Введите начальный баланс первого счёта: ");
            decimal secondBalance = ReadNonNegativeDecimal("Введите начальный баланс второго счёта: ");

            BankAccountType accountType = ReadAccountType();

            BankAccount account1 = new BankAccount(firstBalance, accountType);
            BankAccount account2 = new BankAccount(secondBalance, accountType);

            Console.WriteLine("Счёт отправителя:");
            account1.PrintInformation();
            Console.WriteLine("Счёт получателя:");
            account2.PrintInformation();

            decimal transferAmount = ReadPositiveDecimal("Введите сумму перевода: ");

            account2.TransferMoney(account1, transferAmount);

            Console.WriteLine("После перевода:");

            account1.PrintInformation();
            account2.PrintInformation();
        }

        #endregion

        #region Упражнение 8.2

        static void Task8_2()
        {
            Console.WriteLine("Упражнение 8.2");

            Console.Write("Введите строку: ");
            string text = Console.ReadLine() ?? string.Empty;

            string reversedText = ReverseString(text);

            Console.WriteLine($"Исходная строка: {text}");
            Console.WriteLine($"Обратная строка: {reversedText}");
            Console.WriteLine();
            Console.ReadKey();
        }

        /// <summary>
        /// Возвращает строку с символами в обратном порядке
        /// </summary>
        static string ReverseString(string text)
        {
            char[] characters = text.ToCharArray();
            Array.Reverse(characters);
            return new string(characters);
        }

        #endregion

        #region Упражнение 8.3

        /// <summary>
        /// Записывает содержимое исходного файла в выходной файл заглавными буквами
        /// </summary>
        static void Task8_3()
        {
            Console.WriteLine("Упражнение 8.3");

            Console.Write("Введите имя исходного файла: ");
            string fileName = Console.ReadLine() ?? string.Empty;

            string filesDirectory = Path.Combine(AppContext.BaseDirectory, "Files");

            string inputFile = Path.Combine(filesDirectory, fileName);

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Ошибка: файл не существует.");
                Console.WriteLine($"Программа искала файл здесь: {inputFile}");
                return;
            }

            Console.Write("Введите имя выходного файла: ");
            string outputFile = Console.ReadLine() ?? string.Empty;

            string text = File.ReadAllText(inputFile);
            string upperText = text.ToUpper();
            string outputPath = Path.Combine(filesDirectory, outputFile);

            File.WriteAllText(outputPath, upperText);

            Console.WriteLine();
            Console.WriteLine("Содержимое выходного файла:");

            string outputText = File.ReadAllText(outputPath);

            Console.WriteLine(outputText);
            Console.WriteLine();
            Console.ReadKey();

        }

        #endregion

        #region Упражнение 8.4
        static void Task8_4()
        {
            Console.WriteLine("Упражнение 8.4");

            object firstValue = 125.5m;
            object secondValue = "Пример строки";

            CheckFormattable(firstValue);
            CheckFormattable(secondValue);
            Console.WriteLine();
            Console.ReadKey();
        }

        /// <summary>
        /// Проверяет объект с помощью операторов is и as
        /// </summary>
        static void CheckFormattable(object value)
        {
            if (value is IFormattable)
            {
                IFormattable formattableValue = value as IFormattable;
                Console.WriteLine($"Объект реализует IFormattable. Значение: {formattableValue.ToString(null, null)}");
            }
            else
                Console.WriteLine("Объект не реализует IFormattable");
        }

        #endregion

        #region Домашнее задание 8.1

        /// <summary>
        /// Извлекает адреса электронной почты из исходного файла и записывает их в новый файл
        /// </summary>
        static void DZ8_1()
        {
            Console.WriteLine("Домашнее задание 8.1");

            Console.Write("Введите имя исходного файла: ");
            string fileName = Console.ReadLine() ?? string.Empty;

            string filesDirectory = Path.Combine(AppContext.BaseDirectory, "Files");
            string inputFile = Path.Combine(filesDirectory, fileName);

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Ошибка: файл не существует");
                Console.WriteLine($"Путь поиска: {inputFile}");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите имя выходного файла: ");
            string outputFile = Console.ReadLine() ?? string.Empty;

            string[] lines = File.ReadAllLines(inputFile);
            MailParser parser = new MailParser();
            List<string> emails = new List<string>();

            foreach (string line in lines)
            {
                string email = line;
                parser.SearchMail(ref email);
                if (!string.IsNullOrWhiteSpace(email))
                    emails.Add(email);
            }

            string outputPath = Path.Combine(filesDirectory, outputFile);

            File.WriteAllLines(outputPath, emails);

            Console.WriteLine();
            Console.WriteLine("Содержимое выходного файла:");

            string[] outputLines = File.ReadAllLines(outputPath);

            foreach (string email in outputLines)
                Console.WriteLine(email);

            Console.WriteLine();
            Console.ReadKey();
        }

        #endregion


        #region Домашнее задание 8.2

        /// <summary>
        /// Создаёт список из четырёх песен и проверяет их равенство
        /// </summary>
        static void DZ8_2()
        {
            Console.WriteLine("Домашнее задание 8.2");

            List<Song> songs = new List<Song>();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Введите данные песни №{i + 1}");

                Song song = new Song();

                Console.Write("Название: ");
                string name = Console.ReadLine() ?? string.Empty;
                Console.Write("Автор: ");
                string author = Console.ReadLine() ?? string.Empty;

                song.SetName(name);
                song.SetAuthor(author);

                if (songs.Count > 0)
                    song.SetPrev(songs[songs.Count - 1]);

                songs.Add(song);
            }

            Console.WriteLine();
            Console.WriteLine("Список песен:");

            foreach (Song song in songs)
                song.PrintInformation();

            Console.WriteLine();

            if (songs[0].Equals(songs[1]))
                Console.WriteLine("Песни одинаковые");
            else
                Console.WriteLine("Песни разные");
        }

        #endregion

        #region Методы ввода

        /// <summary>
        /// Считывает положительное денежное значение
        /// </summary>
        static decimal ReadPositiveDecimal(string message)
        {
            decimal value;

            Console.Write(message);

            while (!decimal.TryParse(Console.ReadLine(), out value) || value <= 0)
                Console.Write("Введите число больше нуля: ");

            return value;
        }

        /// <summary>
        /// Считывает неотрицательное денежное значение
        /// </summary>
        static decimal ReadNonNegativeDecimal(string message)
        {
            decimal value;

            Console.Write(message);

            while (!decimal.TryParse(Console.ReadLine(), out value) || value < 0)
                Console.Write("Введите неотрицательное число: ");

            return value;
        }

        /// <summary>
        /// Считывает тип банковского счёта
        /// </summary>
        static BankAccountType ReadAccountType()
        {
            Console.WriteLine("Выберите тип счёта:");
            Console.WriteLine("1 — Дебетовый");
            Console.WriteLine("2 — Накопительный");
            Console.WriteLine("3 — Кредитный");

            int type;

            Console.Write("Ваш выбор: ");

            while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 3)
                Console.Write("Введите число от 1 до 3: ");

            return (BankAccountType)(type - 1);
        }

        #endregion
    }
}
