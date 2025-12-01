using System.Diagnostics;

Color color = Color.red;

for (int i = 0; i < 6; i++)
{
    Action action = GetAction(color);

    DoAction(action);

    color = NextState(color);

    Console.WriteLine();
}

static Action GetAction(Color color)
{
    switch (color)
    {
        case Color.green:

            return Action.go;

        case Color.yellow:

            return Action.wait;

        case Color.red:

            return Action.stop;

        default:

            Debug.Fail("Неизвестный цвет светофора!");
            return Action.stop;
    }
}

static void DoAction(Action action)
{
    switch (action)
    {
        case Action.go:

            Console.WriteLine("Ехать");
            break;

        case Action.stop:

            Console.WriteLine("Стоять");
            break;

        case Action.wait:

            Console.WriteLine("Готовиться");
            break;

        default:

            Debug.Fail("Неизвестное действие!");
            break;
    }
}

static Color NextState(Color color)
{
    int c = (int)color + 1;
    c %= 3;
    return (Color)c;
}

enum Color
{
    red = 0,
    yellow = 1,
    green = 2
}

enum Action
{
    go,
    wait,
    stop
}
