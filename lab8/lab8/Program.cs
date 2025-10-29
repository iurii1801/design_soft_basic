class Program
{
    static void Main()
    {
        int a = ReadNumber("Введите первое число (>2): ");
        int b = ReadNumber("Введите второе число (>2): ");
        int c = ReadNumber("Введите третье число (>2): ");

        int result = (int)a * b * c;
        Console.WriteLine($"Произведение: {result}");
    }

    static int ReadNumber(string message)
    {
        while (true)
        {
            Console.Write(message);
            string s = Console.ReadLine();
            int value;

            if (!int.TryParse(s, out value))
            {
                Console.WriteLine("Ошибка: введите целое число!");
                continue;
            }

            if (value <= 2)
            {
                Console.WriteLine("Число должно быть больше 2.");
                continue;
            }

            return value; 
        }
    }
}
