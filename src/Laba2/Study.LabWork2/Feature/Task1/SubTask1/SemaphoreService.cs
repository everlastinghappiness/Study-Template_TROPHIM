using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Сервис подсчёта простых чисел с использованием Semaphore
/// </summary>
public sealed class SemaphoreService : IPrimeCounter
{
    public PrimeCountResultDto CountPrimes(int startNumber, int endNumber, int threadCount)
    {
        ValidateInput(startNumber, endNumber, threadCount);

        threadCount = Math.Min(threadCount, endNumber - startNumber + 1);

        using var semaphore = new Semaphore(1, 1);

        var consoleLocker = new object();

        var primeCount = 0;
        var stopwatch = Stopwatch.StartNew();

        var threads = CreateThreads(
            startNumber,
            endNumber,
            threadCount,
            (number, threadNumber) =>
            {
                PrintCheckedNumber(threadNumber, number, consoleLocker);

                if (!IsPrime(number))
                {
                    return;
                }

                semaphore.WaitOne();

                try
                {
                    primeCount++;
                }
                finally
                {
                    semaphore.Release();
                }

                PrintPrimeNumber(threadNumber, number, consoleLocker);
            });

        StartAndJoinThreads(threads);

        stopwatch.Stop();

        return new PrimeCountResultDto
        {
            SynchronizationName = "Semaphore",
            StartNumber = startNumber,
            EndNumber = endNumber,
            ThreadCount = threadCount,
            PrimeCount = primeCount,
            ElapsedTime = stopwatch.Elapsed
        };
    }

    private static Thread[] CreateThreads(
        int startNumber,
        int endNumber,
        int threadCount,
        Action<int, int> action)
    {
        var threads = new Thread[threadCount];

        var totalNumbers = endNumber - startNumber + 1;
        var numbersPerThread = totalNumbers / threadCount;
        var remainder = totalNumbers % threadCount;

        var currentStart = startNumber;

        for (var i = 0; i < threadCount; i++)
        {
            var threadNumber = i + 1;
            var rangeLength = numbersPerThread + (i < remainder ? 1 : 0);
            var rangeStart = currentStart;
            var rangeEnd = currentStart + rangeLength - 1;

            currentStart = rangeEnd + 1;

            threads[i] = new Thread(() =>
            {
                for (var number = rangeStart; number <= rangeEnd; number++)
                {
                    action(number, threadNumber);
                }
            });
        }

        return threads;
    }

    private static void StartAndJoinThreads(Thread[] threads)
    {
        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }
    }

    private static bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        if (number == 2)
        {
            return true;
        }

        if (number % 2 == 0)
        {
            return false;
        }

        for (var divisor = 3; divisor * divisor <= number; divisor += 2)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    private static void PrintCheckedNumber(int threadNumber, int number, object consoleLocker)
    {
        lock (consoleLocker)
        {
            Console.WriteLine($"Поток №{threadNumber}: проверяется число {number}");
        }
    }

    private static void PrintPrimeNumber(int threadNumber, int number, object consoleLocker)
    {
        lock (consoleLocker)
        {
            Console.WriteLine($"Поток №{threadNumber}: найдено простое число {number}");
        }
    }

    private static void ValidateInput(int startNumber, int endNumber, int threadCount)
    {
        if (startNumber > endNumber)
        {
            throw new ArgumentException("Начало диапазона не может быть больше конца диапазона.");
        }

        if (threadCount <= 0)
        {
            throw new ArgumentException("Количество потоков должно быть больше нуля.");
        }
    }
}
