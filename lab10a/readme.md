## 1. `if (true)`

```cs
if (true)
{
    Console.WriteLine("Hello");
}
```

Поскольку условие всегда истинно, инструкция внутри блока всегда выполняется. На экран будет выводиться `"Hello"`.

---

## 2. `if (false)`

```cs
if (false)
{
    Console.WriteLine("Hello");
}
```

Тело `if` никогда не будет выполнено. Код компилируется, но будет предупреждение `unreachable code`.

---

## 3. Условие с переменными

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

## 4. Различия между F1, F2, F3

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

## 5. `if (1)`

```cs
if (1)
{
    Console.WriteLine("Hello");
}
```

Код **не скомпилируется**, т.к. `if` принимает только `bool`, а `int` не приводится к `bool` в C#.

---

## 6. `if (false)` с двумя строками

```cs
if (false)
{
    Console.WriteLine("A");
    Console.WriteLine("B");
}
```

Не выведется ничего.

---

## 7. Без скобок

```cs
if (false)
    Console.WriteLine("A");
Console.WriteLine("B");
```

Напечатается только `"B"`.
Только **одна** строка относится к `if`.

---

## 8. `if` + `else`

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

## 9. Изменение переменной внутри `if`

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

## 10. `return` внутри `if`

```cs
F();

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

## 11. `if` без скобок + ещё одна инструкция

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

## 12. Комбинация однострочного `if` и блочного `else`

```cs
if (true)
  Console.WriteLine("A");
else
{
  Console.WriteLine("B");
}
```

Выполнится только строка "A", потому что условие if истинно.

---

## 13. Переписывание цепочки if–else

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

## 14. Сложный пример + guard clause

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

Этот код невозможно представить как цепочку. Некуда поставить "After B" и "After C" так, чтобы они выполнялись по тем же правилам. Можно попробовать их продублировать, но тогда они не будут семантически эквивалентны:

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

###  Вариант через guard clause:

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

**Зачем этот guard clause / early return?**

- Чтобы поднять обработку ошибок вверх функции, а основную логику опустить вниз. Это делает очевидным тот факт, что логика зависит от корректности данных, которая проверялась на момент обработки ошибок (контракт).
- Убирает лишнюю вложенность условий;
- Способствует локальности кода проверки ошибки и ее обработки.

---

## 15. Цикл с break / continue

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

**Что делают `break` и `continue`**

- `break` прекращает выполнение цикла (переходит на первую инструкцию после цикла).
- `continue` переходит в начало цикла (дальнейшие инструкции из тела цикла не выполняются для этой итерации).

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

## 16. Что вернёт функция F(), если ее вызвать?

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
