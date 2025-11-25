## `if (true)`

```cs
if (true)
{
    Console.WriteLine("Hello");
}
```

Поскольку условие всегда истинно, инструкция внутри блока всегда выполняется. На экран будет выводиться `"Hello"`.

---

## `if (false)`

```cs
if (false)
{
    Console.WriteLine("Hello");
}
```

Тело `if` никогда не будет выполнено. Код компилируется, но будет предупреждение `unreachable code`.

---

## Условие с переменными

```cs
bool execute = true;
if (execute)
{
    Console.WriteLine("Hello");
}

bool notExecute = !execute;
if (notExecute)
{
    Console.WriteLine("Not executed");
}
```

Выведется только `"Hello"`, потому что `notExecute` будет `false`.

---

## Различия между F1, F2, F3

Код:

```cs
static void F1()
{
    if (A())
    {
        if (B())
        {
            Console.WriteLine("Hello");
        }
    }
}

static void F2()
{
    if (A() && B())
    {
        Console.WriteLine("Hello");
    }
}

static void F3()
{
    bool a = A();
    bool b = B();
    bool ok = a && b;
    if (ok)
    {
        Console.WriteLine("Hello");
    }
}
```

### Семантика

* **F1 и F2** используют *короткое замыкание*: `B()` не вызывается, если `A()` вернёт `false`.
* **F3** всегда вызывает **оба** метода `A()` и `B()`, независимо от отношения `A()`.

### Функциональность (вывод)

Если `A()` и `B()` всегда возвращают `true`, вывод у всех трёх одинаков:

```
A
B
Hello
```

### Когда появится функциональная разница?

Если `A()` начнёт возвращать `false`, то:

* В **F1/F2** — `B()` не вызовется.
* В **F3** — `B()` всё равно вызовется.

---

## `if (1)`

```cs
if (1)
{
    Console.WriteLine("Hello");
}
```

Код **не скомпилируется**, т.к. `if` принимает только `bool`, а `int` не приводится к `bool` в C#.

---

## `if (false)` с двумя строками

```cs
if (false)
{
    Console.WriteLine("A");
    Console.WriteLine("B");
}
```

Не выведется ничего.

---

## Без скобок

```cs
if (false)
    Console.WriteLine("A");
Console.WriteLine("B");
```

Напечатается только `"B"`.
Только **одна** строка относится к `if`.

---

## `if` + `else`

```cs
if (false)
{
    Console.WriteLine("A");
}
else
{
    Console.WriteLine("B");
}
```

Выведется `"B"`.

---

## Изменение переменной внутри `if`

```cs
bool a = true;
if (a)
{
    a = false;
}
else
{
    Console.WriteLine("B");
}
```

Ничего не напечатается.
Ветка `if/else` определяется **до изменения** переменной внутри блока.

---

## `return` внутри `if`

```cs
static void F()
{
    if (true)
    {
        return;
    }
    else
    {
        Console.WriteLine("B");
    }
}
```

Ничего не выведется, потому что `return` завершает функцию сразу.

---

## `if` без скобок + ещё одна инструкция

```cs
if (true)
    Console.WriteLine("A");
else
    Console.WriteLine("B");
Console.WriteLine("C");
```

Выведет:

```
A
C
```

---

## Переписывание цепочки if–else

Исходный вариант:

```cs
if (a)
{
    Console.WriteLine("A");
}
else
{
    if (b)
    {
        Console.WriteLine("B");
    }
    else
    {
        if (c)
        {
            Console.WriteLine("C");
        }
    }
}
```

Правильная цепочка:

```cs
if (a)
{
    Console.WriteLine("A");
}
else if (b)
{
    Console.WriteLine("B");
}
else if (c)
{
    Console.WriteLine("C");
}
```

---

## Сложный пример + guard clause

Исходный код:

```cs
if (a)
{
    Console.WriteLine("A");
}
else
{
    Console.WriteLine("After A");

    if (b)
    {
        Console.WriteLine("B");
    }
    else
    {
        Console.WriteLine("After B");

        if (c)
        {
            Console.WriteLine("C");
        }
        else
        {
            Console.WriteLine("After C");
        }
    }
}
```

### Цепочка if–else (НЕ полностью эквивалентна, но близкая):

```cs
if (a)
{
    Console.WriteLine("A");
}
else if (b)
{
    Console.WriteLine("After A");
    Console.WriteLine("B");
}
else if (c)
{
    Console.WriteLine("After A");
    Console.WriteLine("After B");
    Console.WriteLine("C");
}
else
{
    Console.WriteLine("After A");
    Console.WriteLine("After B");
    Console.WriteLine("After C");
}
```

### Полностью эквивалентный вариант через guard clause:

```cs
static void F(bool a, bool b, bool c)
{
    if (a)
    {
        Console.WriteLine("A");
        return;
    }
    Console.WriteLine("After A");

    if (b)
    {
        Console.WriteLine("B");
        return;
    }
    Console.WriteLine("After B");

    if (c)
    {
        Console.WriteLine("C");
        return;
    }
    Console.WriteLine("After C");
}
```

Guard clause убирает вложенность и делает логику линейной.

---

## Цикл с break / continue

Код:

```cs
int i = 0;
while (true)
{
    if (i == 4)
    {
        Console.WriteLine("ERROR: Should not happen");
        break;
    }
    if (i == 3)
    {
        Console.WriteLine("Exit");
        break;
    }
    if (i == 0)
    {
        Console.WriteLine("Increase by 2 on first iter");
        i += 2;
        continue;
    }

    Console.WriteLine("Increase by 1 normally");
    i++;
}
```

### Выполнение:

```
Increase by 2 on first iter
Increase by 1 normally
Exit
```

* `"ERROR..."` **не будет**, потому что цикл завершится раньше.
* `continue` пропускает нижний код и возвращает нас к началу цикла.
* `break` выходит из цикла полностью.

---

## Что вернёт функция F()

```cs
static int F()
{
    while (true)
    {
        if (true)
        {
            return 0;
        }
        break;
    }
    return 1;
}
```

Выполняется `return 0`.
`break` и `return 1` недостижимы.
Функция **всегда возвращает 0**.
