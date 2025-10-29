**Что будет, если пользователь не введет строковое представление числа?**
  
```cs
string a = Console.ReadLine()!;
int b = int.Parse(a);
Console.WriteLine(b);
```

> Если пользователь не введёт правильное число или ничего не введёт,
программа упадёт с ошибкой будет вызван exception.

```cs
string a = Console.ReadLine()!;
int b;
bool success = int.TryParse(a, out b);
Console.WriteLine(success);
Console.WriteLine(b);
```

> Если не ввеcти число,
программа не упадёт с ошибкой, а просто выведет: false 0
  
  
**Как работает этот код? Что выведется в консоль?**

```cs
int a = 0;
F(a);
Console.WriteLine(a);

static void F(int a)
{
    a = 1;
}
```

> Выведется 0 (a = 0), потому что а внутри функции локальная(хранится во временной ячейке памяти).

```cs

int a = 0;
F(out a);
Console.WriteLine(a);

static void F(out int b)
{
    b = 1;
}
```

> Выведется 1 (a = 1), потому что по ссылке значение из фукнции передается в глобальную переменную.

```cs
int a = 0;
F(out a);
Console.WriteLine(a);

static void F(out int a)
{
    a = 1;
}
```

> Выведется 1 (a = 1), потому что перменные за функцией и внутри независимы.

```cs
A a;
F(out a);
Console.WriteLine(a.f1);
Console.WriteLine(a.f2);

static void F(out int b)
{
    b = 1;
}

struct A
{
    public int f1;
    public int f2;
}
```

> Этот код не скомпилируется.

ошибка:

CS1503: Argument 1: cannot convert from 'out A' to 'out int' 

```cs
A a;
F(out a);
Console.WriteLine(a.f1);
Console.WriteLine(a.f2);

static void F(out int a)
{
    a = 1;
}

struct A
{
    public int f1;
    public int f2;
}
```

> Будут то же самое что и в предыдущем коде, смена переменной в функции не изменила ничего.

```cs
A a;
F(out a);
Console.WriteLine(a.f1);
Console.WriteLine(a.f2);

static void F(out int a)
{
    a = 1;
}

struct A
{
    public int f1;
    public int f2;
}
```

> Код не скомпилируется, так как не удается преобразовать тип int в A.

```cs
A a;
F(out a);
Console.WriteLine(a.f1);
Console.WriteLine(a.f2);

static void F(out A b)
{
    b.f1 = 1;
}

struct A
{
    public int f1;
    public int f2;
}
```

> Переменная а не полностью инициализирована - нет b.f2.

```cs
A a;
F(out a);
Console.WriteLine(a.f1);
Console.WriteLine(a.f2);

static void F(out A b)
{
    b.f1 = 1;
    b.f2 = 2;
}

struct A
{
    public int f1;
    public int f2;
}
```

> Будет a.f1 = 1, a.f2 = 2

```cs
A a;
F(out a);
Console.WriteLine(a.f1);
Console.WriteLine(a.f2);

static void F(out A b)
{
    b = new()
    {
        f1 = 1,
        f2 = 2,
    };
}

struct A
{
    public int f1;
    public int f2;
}
```

> Будет a.f1 = 1, a.f2 = 2

```cs
int a = 0;
F(out a);
Console.WriteLine(a);

static int F(out int b)
{
    b = 1;
    return 2;
}
```

> а будет 1, так как возвращаемое значение не сохраняется нигде.

```cs

int a = 0;
int b = 0;
b = F(out a);
Console.WriteLine(a);
Console.WriteLine(b);

static int F(out int c)
{
    c = 1;
    return 2;
}
```

> Будет a = 1, b = 2, потому что в перменную b сохраняем возвращаемое значение.

```cs
int a;
int b;
F(out a, out b);
Console.WriteLine(a);
Console.WriteLine(b);

static void F(out int c, out int d)
{
    c = 1;
    d = 2;
}
```

> Будет a = 1, b = 2