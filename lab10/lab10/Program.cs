struct Book
{
    public string? Title;
    public int Year;
    public bool IsBorrowed;
}

class Program
{
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

        Functions.Menu(books);
    }
}
