namespace FIOParser
{
    class Program
    {
        static void Main(string[] args)
        {
            // Получить ФИО от пользователя
            Console.WriteLine("Введите ваше ФИО:");
            string fio = Console.ReadLine();

            // Разделить ФИО на отдельные элементы
            List<string> fioParts = fio.Split(' ').ToList();

            // Вывести список операций
            Console.WriteLine("Выберите операцию из списка:");
            Console.WriteLine("1. Вытащить фамилию, имя или отчество отдельно");
            Console.WriteLine("2. Отсортировать свою фамилию по возрастанию или убыванию");
            Console.WriteLine("3. Изменить своё имя, фамилию, отчество");
            Console.WriteLine("4. Посчитать количество согласных в фамилии");
            Console.WriteLine("5. Проверить, начинается ли фамилия с гласной");

            // Получить номер операции от пользователя
            int operationNumber = int.Parse(Console.ReadLine());

            // Выполнить выбранную операцию
            switch (operationNumber)
            {
                case 1:
                    // Вывести фамилию, имя и отчество отдельно
                    Console.WriteLine("Фамилия: {0}", fioParts[0]);
                    Console.WriteLine("Имя: {0}", fioParts[1]);
                    Console.WriteLine("Отчество: {0}", fioParts[2]);
                    break;
                case 2:
                    // Отсортировать фамилию по возрастанию или убыванию
                    fioParts[0] = SortLastName(fioParts[0]);
                    Console.WriteLine("Отсортированная фамилия: {0}", fioParts[0]);
                    break;
                case 3:
                    // Изменить имя, фамилию и отчество
                    Console.WriteLine("Введите новое имя:");
                    fioParts[1] = Console.ReadLine();
                    Console.WriteLine("Введите новую фамилию:");
                    fioParts[0] = Console.ReadLine();
                    Console.WriteLine("Введите новое отчество:");
                    fioParts[2] = Console.ReadLine();
                    Console.WriteLine("Измененное ФИО: {0}", string.Join(" ", fioParts));
                    break;
                case 4:
                    // Посчитать количество согласных в фамилии
                    int consonantCount = CountConsonants(fioParts[0]);
                    Console.WriteLine("Количество согласных в фамилии: {0}", consonantCount);
                    break;
                case 5:
                    bool startsWithVowel = startsWithVowel(fioParts[0]);
                    string result = startsWithVowel ? "Фамилия начинается с гласной" : "Фамилия не начинается с гласной";
                    Console.WriteLine(result);
                    break;
                default:
                    Console.WriteLine("Введена неверная операция");
                    break;
            }

            Console.ReadKey();
        }
        static string SortLastName(string lastName)
        {
            // Преобразовать фамилию в массив символов
            char[] lastNameChars = lastName.ToCharArray();

            // Сортировать массив
            Array.Sort(lastNameChars);

            // Преобразовать обратно в строку
            return new string(lastNameChars);
        }
        static int CountConsonants(string lastName)
        {
            int count = 0;

            // Цикл по каждому символу в фамилии
            foreach (char c in lastName)
            {
                // Проверить, является ли символ согласной
                if (!IsVowel(c))
                {
                    count++;
                }
            }

            return count;
        }
        static bool IsVowel(char c)
        {
            // Преобразовать в нижний регистр
            c = char.ToLower(c);

            // Проверить, является ли символ гласной
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }
    }
}