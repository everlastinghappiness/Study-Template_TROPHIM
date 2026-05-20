namespace Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

/// <summary>
/// Результат обработки всех наборов чисел
/// </summary>
public sealed class ProcessingResultDto
{
    /// <summary>
    /// Результаты обработки наборов
    /// </summary>
    public IReadOnlyList<ResultEntryDto> Results { get; set; } = [];

    /// <summary>
    /// Общий итог по всем наборам
    /// </summary>
    public int TotalSum { get; set; }

    /// <summary>
    /// Время выполнения
    /// </summary>
    public TimeSpan ElapsedTime { get; set; }
}
