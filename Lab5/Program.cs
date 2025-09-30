using System;

namespace Lab05
{
    struct Prices
    {
        public int DrinkPerGram;
        public int FirstPerGram;
        public int SecondPerGram;
    }

    struct Choices
    {
        public int DrinkGrams;
        public int FirstGrams;
        public int SecondGrams;
    }

    class Program
    {
        static int CustomerTotal(Prices prices, Choices choices)
        {
            int drinkCost = choices.DrinkGrams * prices.DrinkPerGram;
            int firstCost = choices.FirstGrams * prices.FirstPerGram;
            int secondCost = choices.SecondGrams * prices.SecondPerGram;
            return drinkCost + firstCost + secondCost;
        }

        static void Main()
        { 
            Prices prices = new()
            {
                DrinkPerGram = 10,
                FirstPerGram = 20,
                SecondPerGram = 30
            };

            int client1_total;
            int client2_total;

            {
                Choices client1 = new()
                {
                    DrinkGrams = 100,
                    FirstGrams = 0,
                    SecondGrams = 250
                };

                client1_total = CustomerTotal(prices, client1);
            }

            {
                Choices client2 = new()
                {
                    DrinkGrams = 0,
                    FirstGrams = 300,
                    SecondGrams = 0
                };

                client2_total = CustomerTotal(prices, client2);
            }

            Console.WriteLine($"Стоимость заказа клиента 1: {client1_total}");
            Console.WriteLine($"Стоимость заказа клиента 2: {client2_total}");
        }
    }
}
