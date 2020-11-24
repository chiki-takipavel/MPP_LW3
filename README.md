# MPP_LW3
## Лабораторная работа №3
**Задача 1.**

Создать класс на языке C#, который:
- называется `Mutex` и реализует двоичный семафор с помощью атомарной операции `Interlocked.CompareExchange`;
- обеспечивает блокировку и разблокировку двоичного семафора с помощью public-методов `Lock` и `Unlock`.

**Задача 2.**

Создать класс на языке C#, который:
- называется `OSHandle` и обеспечивает автоматическое или принудительное освобождение заданного дескриптора операционной системы;
- содержит свойство `Handle`, позволяющее установить и получить дескриптор операционной системы;
- реализует метод `Finalize` для автоматического освобождения дескриптора;
- реализует интерфейс `IDisposable` для принудительного освобождения дескриптора.
