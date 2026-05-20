using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;
using Study.LabWork2.Feature.Task1.SubTask1;
using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2;

/// <summary>
/// Начальная точка входа
/// </summary>
public static class Program
{
    /// <summary>
    /// Номер выполняемой задачи
    /// </summary>
    private const int RUN_TASK_NUMBER = 1;

    private const int START_NUMBER = 1;

    private const int END_NUMBER = 10_000;

    private const int THREAD_COUNT = 4;

    private const int MAX_PARALLEL_THREADS = 3;

    /// <summary>
    /// Старт программы
    /// </summary>
    public static void Main()
    {
        switch (RUN_TASK_NUMBER)
        {
            case 1:
                RunTask1();
                break;
            default:
                throw new NotSupportedException();
        }
    }

    private static void RunTask1()
    {
        RunSubTask1();
        Console.WriteLine();
        RunSubTask2();
    }

    private static void RunSubTask1()
    {
        Console.WriteLine("Лабораторная работа 2");
        Console.WriteLine("Задание 1.1");
        Console.WriteLine();

        IPrimeCounter[] services =
        [
            new MonitorService(),
            new MutexService(),
            new SemaphoreService()
        ];

        foreach (var service in services)
        {
            var result = service.CountPrimes(START_NUMBER, END_NUMBER, THREAD_COUNT);

            PrintPrimeCountResult(result);
            Console.WriteLine();
        }
    }

    private static void RunSubTask2()
    {
        Console.WriteLine("Лабораторная работа 2");
        Console.WriteLine("Задание 1.2");
        Console.WriteLine();

        var processor = new NumberSetProcessor();
        var numberSets = NumberSetProcessor.CreateDefaultNumberSets();

        var result = processor.Process(numberSets, MAX_PARALLEL_THREADS);

        PrintProcessingResult(result);
    }

    private static void PrintPrimeCountResult(PrimeCountResultDto result)
    {
        Console.WriteLine($"Способ синхронизации: {result.SynchronizationName}");
        Console.WriteLine($"Диапазон: от {result.StartNumber} до {result.EndNumber}");
        Console.WriteLine($"Количество потоков: {result.ThreadCount}");
        Console.WriteLine($"Общее количество простых чисел: {result.PrimeCount}");
        Console.WriteLine($"Время выполнения: {result.ElapsedTime.TotalMilliseconds} мс");
    }

    private static void PrintProcessingResult(ProcessingResultDto result)
    {
        foreach (var entry in result.Results)
        {
            Console.WriteLine(
                $"Набор №{entry.SetNumber}: сумма = {entry.Sum}, поток = {entry.ThreadId}");
        }

        Console.WriteLine();
        Console.WriteLine($"Общий итог по всем наборам: {result.TotalSum}");
        Console.WriteLine($"Время выполнения: {result.ElapsedTime.TotalMilliseconds} мс");
    }
}
