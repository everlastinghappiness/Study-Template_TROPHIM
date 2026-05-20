using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask2;

/// <summary>
/// Обработчик наборов чисел
/// </summary>
public sealed class NumberSetProcessor : INumberSetProcessor
{
    private static readonly string[] DefaultRawNumberSets =
    [
        "48 4 86 65 67 19 26 84 60 1 2 78 94 21 69 42 22 55 64 98 60 58 54 14 61 51 22 52 53 84 45 3 58 28 36 3 95 59 9 54 37 75 12 87 7 31 17 67 1 37 34 46 81 10 31 90 52 64 71 10 66 39 6 55 30 93 28 90 32 25 35 80 95 36 27 65 39 27 77 92 10 65 11 71 78 25 19 2 82 61 19 56 48 76 4 6 16 3 63 38",
        "22 41 59 31 4 87 54 56 63 50 99 45 96 33 29 10 25 75 12 26 10 62 56 17 77 15 96 50 12 44 36 7 88 44 31 95 18 18 25 86 63 20 81 18 42 76 76 43 74 32 77 86 10 61 90 20 94 52 33 61 51 96 91 47 20 49 52 1 12 98 50 40 67 55 6 56 21 8 83 65 57 87 67 35 79 42 65 100 62 28 38 92 51 46 71 13 57 30 89 96",
        "3 90 36 10 36 78 29 34 23 5 53 27 23 4 9 92 46 54 50 82 18 18 59 87 92 23 98 43 82 71 59 38 72 34 1 54 99 56 11 84 36 52 26 72 62 80 30 86 27 13 30 100 60 88 87 68 9 1 50 85 47 34 99 37 87 29 2 79 62 56 59 90 10 36 74 3 7 94 31 47 50 53 4 24 85 49 33 83 47 31 53 77 3 56 20 27 58 44 63 13",
        "37 34 62 26 14 70 9 79 57 61 90 35 13 24 27 32 81 27 10 21 12 66 3 52 65 58 78 51 7 25 7 73 30 82 76 42 62 88 52 86 10 23 75 84 41 77 81 74 22 29 23 61 23 92 68 23 48 12 14 87 52 49 31 25 76 89 16 49 30 5 59 10 76 41 65 36 76 67 30 12 68 51 78 31 31 27 85 12 23 47 17 47 8 42 26 29 55 32 52 18",
        "37 92 46 87 69 15 64 11 21 83 58 64 28 55 81 51 100 95 85 60 99 33 85 24 73 86 41 27 36 77 95 100 85 14 44 8 35 71 15 4 87 9 3 45 80 5 7 3 68 100 39 48 25 17 96 29 63 72 93 25 61 62 82 53 8 34 13 7 30 18 58 85 94 89 95 21 25 39 48 5 1 10 54 24 79 29 62 100 66 70 35 91 27 6 91 89 85 46 76 17",
        "65 34 70 29 67 79 32 71 63 23 91 86 16 8 57 56 100 32 2 81 82 13 28 4 33 34 1 94 52 41 97 27 39 64 88 58 16 44 94 95 99 65 3 99 17 97 10 96 9 94 65 28 45 67 3 7 6 28 8 78 47 74 89 33 20 86 66 82 3 80 4 62 6 95 18 23 33 50 4 58 16 14 74 88 33 100 71 38 33 65 24 16 39 15 37 6 22 58 45 75",
        "56 9 57 94 79 53 83 43 92 99 5 95 49 80 99 59 80 85 19 20 82 63 93 16 55 56 95 96 12 79 36 87 84 85 13 67 99 30 44 31 94 1 42 26 27 35 37 6 36 79 47 11 89 18 49 65 77 41 54 36 48 31 98 41 53 22 69 92 93 45 41 25 77 5 76 49 55 72 25 57 95 23 25 53 55 62 23 88 36 53 81 52 8 47 84 10 4 2 98 47",
        "21 24 16 87 74 66 22 30 38 22 95 91 76 35 28 34 12 99 43 24 78 13 87 21 25 49 57 15 55 86 1 98 63 42 1 39 7 99 76 80 99 6 60 69 9 84 80 60 55 46 42 40 2 48 32 39 65 7 68 16 48 82 94 84 40 8 71 25 1 92 17 55 41 34 77 16 69 23 94 3 63 26 20 62 31 91 47 56 84 15 10 20 57 91 69 24 91 82 14 77",
        "5 39 17 32 19 58 72 59 80 6 49 2 26 34 97 22 11 49 88 2 96 81 97 81 42 41 5 3 97 84 48 19 97 39 16 27 78 100 68 44 57 69 23 86 15 69 29 81 68 74 75 3 96 30 97 95 99 67 5 80 50 23 38 85 86 17 14 75 54 27 58 45 35 10 85 97 19 5 78 45 80 16 88 8 4 56 78 16 64 67 98 81 27 45 91 53 56 2 84 56",
        "19 79 31 45 89 3 71 68 98 52 10 35 16 100 53 39 86 45 5 35 31 25 58 53 50 15 95 74 15 10 25 99 12 27 58 29 71 64 70 81 80 96 88 78 19 69 58 50 5 69 10 48 23 56 17 59 30 73 34 74 7 16 70 37 77 49 18 45 15 33 22 76 57 91 61 44 61 2 52 75 96 7 58 46 24 43 76 93 98 28 34 25 26 4 30 36 71 5 80 47",
        "51 46 69 26 68 82 41 14 77 96 49 52 30 98 48 48 39 74 21 84 43 20 11 3 99 53 84 49 20 86 44 31 85 6 86 63 49 56 74 9 56 33 34 72 39 84 11 59 68 85 71 62 93 10 57 89 44 52 59 83 17 78 18 30 82 4 56 59 56 46 73 76 39 43 84 81 1 99 26 83 67 4 93 21 73 51 95 46 46 81 80 12 32 61 93 75 36 98 9 12",
        "13 68 98 3 2 89 61 17 47 87 43 79 67 100 42 37 82 6 85 46 45 95 29 76 95 27 47 4 47 25 51 89 49 21 46 28 33 97 13 71 39 79 90 53 82 26 2 12 11 25 24 80 5 27 56 2 78 50 31 71 84 82 17 54 80 74 47 17 31 50 87 58 87 30 72 51 19 72 38 69 71 69 18 39 81 51 89 97 80 95 25 18 7 19 87 68 65 70 28 67",
        "22 95 48 64 24 41 96 12 23 70 2 27 41 48 81 89 44 75 36 28 70 3 62 96 4 3 42 37 81 59 91 19 69 70 42 84 57 96 50 84 36 72 9 14 50 54 94 91 87 72 5 31 84 25 8 49 27 57 59 9 46 71 26 93 85 11 70 84 5 50 99 53 41 31 69 63 16 68 89 86 67 72 9 34 38 16 60 70 95 59 32 50 70 5 86 87 28 15 81 47",
        "23 81 37 34 16 71 98 51 25 57 47 3 8 23 64 36 15 97 100 64 3 23 49 8 92 49 37 83 83 98 11 62 59 7 22 3 42 90 1 8 63 74 29 96 16 49 1 47 11 90 38 8 31 49 20 34 17 20 94 55 52 38 37 3 61 1 40 14 71 58 80 96 79 78 14 63 65 37 57 96 27 32 69 10 65 5 86 39 33 81 96 30 94 38 65 9 10 43 58 27",
        "38 3 46 77 21 6 62 95 54 85 92 43 36 99 24 74 17 6 57 2 53 7 20 42 98 32 79 76 90 76 1 23 64 49 62 45 71 27 85 29 27 27 82 35 95 50 60 98 60 74 96 56 89 69 14 18 26 31 34 90 75 37 22 13 42 5 19 83 61 72 41 6 25 39 41 15 29 80 48 23 27 78 42 88 62 59 1 74 64 17 31 6 62 36 88 19 46 82 67 35"
    ];

    public ProcessingResultDto Process(
        IReadOnlyList<IReadOnlyList<int>> numberSets,
        int maxParallelThreads)
    {
        ValidateInput(numberSets, maxParallelThreads);

        using var semaphore = new Semaphore(maxParallelThreads, maxParallelThreads);
        using var totalMutex = new Mutex();

        var resultLocker = new object();
        var results = new List<ResultEntryDto>();
        var totalSum = 0;

        var stopwatch = Stopwatch.StartNew();

        var threads = new Thread[numberSets.Count];

        for (var i = 0; i < numberSets.Count; i++)
        {
            var setNumber = i + 1;
            var numbers = numberSets[i];

            threads[i] = new Thread(() =>
            {
                semaphore.WaitOne();

                try
                {
                    var sum = numbers.Sum();
                    var threadId = Environment.CurrentManagedThreadId;

                    lock (resultLocker)
                    {
                        results.Add(new ResultEntryDto
                        {
                            SetNumber = setNumber,
                            Sum = sum,
                            ThreadId = threadId
                        });
                    }

                    totalMutex.WaitOne();

                    try
                    {
                        totalSum += sum;
                    }
                    finally
                    {
                        totalMutex.ReleaseMutex();
                    }
                }
                finally
                {
                    semaphore.Release();
                }
            });
        }

        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        stopwatch.Stop();

        return new ProcessingResultDto
        {
            Results = results.OrderBy(result => result.SetNumber).ToList(),
            TotalSum = totalSum,
            ElapsedTime = stopwatch.Elapsed
        };
    }

    public static IReadOnlyList<IReadOnlyList<int>> CreateDefaultNumberSets()
    {
        return DefaultRawNumberSets
            .Select(ParseNumberSet)
            .ToList();
    }

    private static IReadOnlyList<int> ParseNumberSet(string rawNumberSet)
    {
        var numbers = rawNumberSet
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        if (numbers.Length != 100)
        {
            throw new InvalidOperationException("Каждый набор должен содержать ровно 100 чисел.");
        }

        return numbers;
    }

    private static void ValidateInput(
        IReadOnlyList<IReadOnlyList<int>> numberSets,
        int maxParallelThreads)
    {
        if (numberSets.Count == 0)
        {
            throw new ArgumentException("Список наборов чисел не может быть пустым.");
        }

        if (maxParallelThreads <= 0)
        {
            throw new ArgumentException("Максимальное количество потоков должно быть больше нуля.");
        }

        foreach (var numberSet in numberSets)
        {
            if (numberSet.Count == 0)
            {
                throw new ArgumentException("Набор чисел не может быть пустым.");
            }
        }
    }
}
