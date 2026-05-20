using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Abstractions.Feature.Task1.SubTask1;

/// <summary>
/// Интерфейс сервиса подсчёта простых чисел
/// </summary>
public interface IPrimeCounter
{
    /// <summary>
    /// Подсчитать количество простых чисел
    /// </summary>
    PrimeCountResultDto CountPrimes(int startNumber, int endNumber, int threadCount);
}
