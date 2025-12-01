static class Functions
{
    public static void ViewAll(Book[] books)
    {
        Console.WriteLine("\nСписок книг библиотеки:");

        for (int i = 0; i < books.Length; i++)
        {
            string status = books[i].IsBorrowed ? "занята" : "свободна";
            Console.WriteLine($"{i + 1}. {books[i].Title} ({books[i].Year}) — {status}");
        }

        Console.WriteLine();
    }

    public static void Borrow(Book[] books, string name)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].Title!.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                if (books[i].IsBorrowed)
                    Console.WriteLine("Эта книга уже занята.");
                else
                {
                    books[i].IsBorrowed = true;
                    Console.WriteLine("Вы взяли книгу.");
                }
                return;
            }
        }

        Console.WriteLine("Книга не найдена.");
    }

    public static void Return(Book[] books, string name)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].Title!.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                if (!books[i].IsBorrowed)
                    Console.WriteLine("Эта книга и так свободна.");
                else
                {
                    books[i].IsBorrowed = false;
                    Console.WriteLine("Вы вернули книгу.");
                }
                return;
            }
        }

        Console.WriteLine("Книга не найдена.");
    }

    public static void Menu(Book[] books)
    {
        while (true)
        {
            Console.WriteLine("\n1 — Показать все книги");
            Console.WriteLine("2 — Взять книгу");
            Console.WriteLine("3 — Вернуть книгу");
            Console.WriteLine("0 — Выход");
            Console.Write("Введите команду: ");

            string cmd = Console.ReadLine()!;

            switch (cmd)
            {
                case "1":
                    Functions.ViewAll(books);
                    break;

                case "2":
                    Console.Write("Введите название книги: ");
                    string borrowName = Console.ReadLine()!;
                    Functions.Borrow(books, borrowName);
                    break;

                case "3":
                    Console.Write("Введите название книги: ");
                    string returnName = Console.ReadLine()!;
                    Functions.Return(books, returnName);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        }
    }
}
