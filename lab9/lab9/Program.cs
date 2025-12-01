struct Book
{
    public string? Title;
    public int Year;
    public bool IsBorrowed;
}

class Program
{
    static void ViewAll(Book[] books)
    {
        Console.WriteLine("\nСписок книг библиотеки:");

        for (int i = 0; i < books.Length; i++)
        {
            string status = books[i].IsBorrowed ? "занята" : "свободна";
            Console.WriteLine($"{i + 1}. {books[i].Title} ({books[i].Year}) — {status}");
        }
        Console.WriteLine();
    }

    static void Borrow(Book[] books, string name)
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

    static void Return(Book[] books, string name)
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

    static void Menu(Book[] books)
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
                    ViewAll(books);
                    break;

                case "2":
                    Console.Write("Введите название книги: ");
                    string borrowName = Console.ReadLine()!;
                    Borrow(books, borrowName);
                    break;

                case "3":
                    Console.Write("Введите название книги: ");
                    string returnName = Console.ReadLine()!;
                    Return(books, returnName);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        }
    }

    static void Main()
    {
        Book[] books = new Book[]
        {
            new Book { Title = "Восстание Мстителей", Year = 2015, IsBorrowed = false },
            new Book { Title = "Паук-версия",        Year = 2014, IsBorrowed = false },
            new Book { Title = "Секретные войны",    Year = 2015, IsBorrowed = false },
            new Book { Title = "Старик Логан",       Year = 2008, IsBorrowed = false },
            new Book { Title = "Железный человек: Демон в бутылке", Year = 1979, IsBorrowed = false }
        };

        Menu(books);
    }
}
