using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

namespace Study.LabWork2.Abstractions.Feature.Task1.SubTask2;

/// <summary>
/// Интерфейс обработчика наборов чисел
/// </summary>
public interface INumberSetProcessor
{
    /// <summary>
    /// Обработать наборы чисел
    /// </summary>
    ProcessingResultDto Process(
        IReadOnlyList<IReadOnlyList<int>> numberSets,
        int maxParallelThreads);
}
