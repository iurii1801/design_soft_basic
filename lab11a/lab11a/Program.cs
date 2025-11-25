using System.Diagnostics;

Colors color = Colors.red;

for (int i = 0; i < 6; i++)
{
    Actions act = GetAction(color);
    DoAction(act);
    color = NextState(color);
    Console.WriteLine();
}

static Actions GetAction(Colors color)
{
    switch (color)
    {
        case Colors.green:
            return Actions.go;
        case Colors.red:
            return Actions.stop;
        case Colors.yellow:
            return Actions.wait;
        default:
            Debug.Fail("Неизвестный цвет светофора!");
            return Actions.stop;
    }
}

static void DoAction(Actions act)
{
    switch (act)
    {
        case Actions.go:
            Console.WriteLine("Действие - ехать");
            break;
        case Actions.stop:
            Console.WriteLine("Действие - ждать");
            break;
        case Actions.wait:
            Console.WriteLine("Действие - готовиться");
            break;
        default:
            Debug.Fail("Неизвестное действие!");
            break;
    }
}

static Colors NextState(Colors color)
{
    switch (color)
    {
        case Colors.red:
            return Colors.yellow;
        case Colors.yellow:
            return Colors.green;
        case Colors.green:
            return Colors.red;    
        default:
            Debug.Fail("Неизвестный цвет!");
            return Colors.red;
    }
}

enum Colors
{
    red,
    yellow,
    green
}

enum Actions
{
    go,
    wait,
    stop
}
