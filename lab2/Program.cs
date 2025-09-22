using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Hello, Jerry");
        Console.WriteLine("--------------------");

        for (int i = 0; i < 3; i++)
        {
            ABC();
            Thread.Sleep(500); 
        }

        Console.WriteLine("--------------------");

        A();
        A();

    }

    static void ABC()
    {
        Console.WriteLine("A");
        Console.WriteLine("B");
        Console.WriteLine("C");
    }

    static void A()
    {
        Console.WriteLine("A");
        B();
        C();
    }

    static void B()
    {
        Console.WriteLine("B");
    }

    static void C()
    {
        Console.WriteLine("C");
    }
}
