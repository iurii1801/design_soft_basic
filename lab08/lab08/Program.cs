struct Book
{
    public string Title;
    public int Year;
    public bool IsBorrowed;
}

class Library
{
    private Book[] books = new Book[5]
    {
        new Book { Title = "Восстание Мстителей", Year = 2015 },
        new Book { Title = "Паук-версия", Year = 2014 },
        new Book { Title = "Секретные войны", Year = 2015 },
        new Book { Title = "Старик Логан", Year = 2008 },
        new Book { Title = "Железный человек: Демон в бутылке", Year = 1979 }
    };

    public void ViewAll()
    {
        Console.WriteLine("\nСписок книг Marvel-библиотеки:");

        for (int i = 0; i < books.Length; i++)
        {
            string status;

            if (books[i].IsBorrowed)
                status = "взята";
            else
                status = "в наличии";

            Console.WriteLine((i + 1) + ". " + books[i].Title + " (" + books[i].Year + ") — " + status);
        }

        Console.WriteLine();
    }

    public void Borrow(string title)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].Title == title)
            {
                if (books[i].IsBorrowed)
                {
                    Console.WriteLine($"Книга \"{title}\" уже была взята.\n");
                    return;
                }

                books[i].IsBorrowed = true;
                Console.WriteLine($"Книга \"{title}\" успешно взята.\n");
                return;
            }
        }

        Console.WriteLine("Ошибка: книги с таким названием нет в библиотеке.\n");
    }

    public void Return(string title)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].Title == title)
            {
                if (!books[i].IsBorrowed)
                {
                    Console.WriteLine($"Книга \"{title}\" уже находится в библиотеке.\n");
                    return;
                }

                books[i].IsBorrowed = false;
                Console.WriteLine($"Книга \"{title}\" успешно возвращена.\n");
                return;
            }
        }

        Console.WriteLine("Ошибка: книги с таким названием нет в библиотеке.\n");
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library(); 

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

            if (choice == "0")
            {
                Console.WriteLine("Выход из программы...");
                break;
            }

            switch (choice)
            {
                case "1":
                    library.ViewAll();
                    break;

                case "2":
                    Console.Write("Введите название книги, которую хотите взять: ");
                    string borrowTitle = Console.ReadLine();
                    library.Borrow(borrowTitle);
                    break;

                case "3":
                    Console.Write("Введите название книги, которую хотите вернуть: ");
                    string returnTitle = Console.ReadLine();
                    library.Return(returnTitle);
                    break;

                default:
                    Console.WriteLine("Неизвестная команда. Попробуйте ещё раз.\n");
                    break;
            }
        }
    }
}
