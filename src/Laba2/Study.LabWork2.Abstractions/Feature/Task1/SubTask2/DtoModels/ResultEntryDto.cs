namespace Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

/// <summary>
/// Результат обработки одного набора чисел
/// </summary>
public sealed class ResultEntryDto
{
    /// <summary>
    /// Номер набора
    /// </summary>
    public int SetNumber { get; set; }

    /// <summary>
    /// Сумма чисел набора
    /// </summary>
    public int Sum { get; set; }

    /// <summary>
    /// Номер потока
    /// </summary>
    public int ThreadId { get; set; }
}
