namespace Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

/// <summary>
/// Результат подсчёта простых чисел
/// </summary>
public sealed class PrimeCountResultDto
{
    /// <summary>
    /// Название способа синхронизации
    /// </summary>
    public string SynchronizationName { get; set; } = string.Empty;

    /// <summary>
    /// Начало диапазона
    /// </summary>
    public int StartNumber { get; set; }

    /// <summary>
    /// Конец диапазона
    /// </summary>
    public int EndNumber { get; set; }

    /// <summary>
    /// Количество потоков
    /// </summary>
    public int ThreadCount { get; set; }

    /// <summary>
    /// Количество найденных простых чисел
    /// </summary>
    public int PrimeCount { get; set; }

    /// <summary>
    /// Время выполнения
    /// </summary>
    public TimeSpan ElapsedTime { get; set; }
}
