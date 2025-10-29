**Что произойдет в программе? Что выведется?**
  
```cs
bool a = true;
Console.WriteLine(a);
```

> Будет текстовое True

```cs
bool a = null;
```

> Код не скомпилируется, bool не может содержать null.

```cs
bool a = 1 == 2;
Console.WriteLine(a);
```

> Будет a = false

```cs
int x = 3;
int y = 4;
bool b = x == y;
Console.WriteLine(b);
```

> Будет b = false

```cs
int x = 3;
int y = 4;
bool b = x * 2 == y + 4;
Console.WriteLine(b);
```

> Будет b = false, 6 != 8

```cs
bool a = 1 > 2;
a = 3 == 3;
Console.WriteLine(a);
```

> Переменная a перезапишется с false на true.

```cs
bool a = true;
F(a);

static void F(bool x)
{
    Console.WriteLine(x);
}
```

> Будет текстовое true

```cs
F(5 > 3);

static void F(bool flag)
{
    Console.WriteLine(flag);
}
```

> Будет true, потому что выражение правильное.

```cs
bool result = F();
Console.WriteLine(result);

static bool F()
{
    return true;
}
```

> Будет true

```cs
bool result = IsGreater(5, 3);
Console.WriteLine(result);

static bool IsGreater(int a, int b)
{
    return a > b;
}
```

> Будет true

```cs
bool a = true;
bool b = false;
bool c = a == b;
Console.WriteLine(c);
```

> Будет c = false, потому что true != false

```cs
bool a = false;
bool b = !a;
Console.WriteLine(b);
```

> Будет true

```cs
bool a = true;
bool b = false;
bool c = a && b;
Console.WriteLine(c);
```

> Будет c = false, потому что логическое true и false = false

```cs
bool result = A() && B();
 
static bool A()
{
    Console.WriteLine("A");
    return true;
}
 
static bool B()
{
    Console.WriteLine("B");
    return true;
}
```

> Будет выведено A B и после выполнения result будет иметь значение: true

```cs
bool result = A() && B();
 
static bool A()
{
    Console.WriteLine("A");
    return true;
}
 
static bool B()
{
    Console.WriteLine("B");
    return false;
}
```

> Будет выведено A B и после выполнения result будет иметь значение: false

```cs
bool result = A() && B();

static bool A()
{
    Console.WriteLine("A");
    return false;
}

static bool B()
{
    Console.WriteLine("B");
    return true;
}
```

> Будет выведена A, потому что первое false и второе не выполнится, result будет иметь значение: false

```cs
bool result = A() || B();

static bool A()
{
    Console.WriteLine("A");
    return true;
}

static bool B()
{
    Console.WriteLine("B");
    return true;
}
```

> Будет выведена A и после выполнения result будет иметь значение: true