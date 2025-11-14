struct Book
{
    public string Title;
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
            string status;

            if (books[i].IsBorrowed)
                status = "взята";
            else
                status = "в наличии";

            Console.WriteLine($"{i + 1}. {books[i].Title} {books[i].Year} {status}");
        }

        Console.WriteLine();
    }

    static void Borrow(Book[] books, string title)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].Title == title)
            {
                if (books[i].IsBorrowed)
                {
                    Console.WriteLine("Эта книга уже была взята.\n");
                    return;
                }

                books[i].IsBorrowed = true;
                Console.WriteLine("Книга успешно взята.\n");
                return;
            }
        }

        Console.WriteLine("Ошибка: книги с таким названием нет.\n");
    }

    static void Return(Book[] books, string title)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].Title == title)
            {
                if (!books[i].IsBorrowed)
                {
                    Console.WriteLine("Эта книга уже находится в библиотеке.\n");
                    return;
                }

                books[i].IsBorrowed = false;
                Console.WriteLine("Книга успешно возвращена.\n");
                return;
            }
        }

        Console.WriteLine("Ошибка: книги с таким названием нет.\n");
    }

    static void Menu(Book[] books)
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1 — Показать все книги");
            Console.WriteLine("2 — Взять книгу");
            Console.WriteLine("3 — Вернуть книгу");
            Console.WriteLine("0 — Выход");
            Console.Write("Выберите опцию: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    ViewAll(books);
                    break;

                case "2":
                    Console.Write("Введите название книги: ");
                    string borrowName = Console.ReadLine();
                    Borrow(books, borrowName);
                    break;

                case "3":
                    Console.Write("Введите название книги: ");
                    string returnName = Console.ReadLine();
                    Return(books, returnName);
                    break;

                case "0":
                    Console.WriteLine("Выход...");
                    return;

                default:
                    Console.WriteLine("Неизвестная команда.\n");
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
