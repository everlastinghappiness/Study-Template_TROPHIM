using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Сервис запуска заданий лабораторной работы
/// </summary>
public sealed class RunService
{
    /// <summary>
    /// Запуск задания 1
    /// </summary>
    public void RunTask1()
    {
        Console.WriteLine("Лабораторная работа 1");
        Console.WriteLine("Задание 1");
        Console.WriteLine("Вариант 1: Rational Number");
        Console.WriteLine();

        var first = new RationalNumber(5, 10);
        var second = new RationalNumber(-3, 4);

        Console.WriteLine("Создание дробей:");
        Console.WriteLine($"first = new RationalNumber(5, 10) => {first}");
        Console.WriteLine($"second = new RationalNumber(-3, 4) => {second}");
        Console.WriteLine();

        Console.WriteLine("Арифметические операции:");
        Console.WriteLine($"{first} + {second} = {first + second}");
        Console.WriteLine($"{first} - {second} = {first - second}");
        Console.WriteLine($"{first} * {second} = {first * second}");
        Console.WriteLine($"{first} / {second} = {first / second}");
        Console.WriteLine();

        Console.WriteLine("Операции сравнения:");
        Console.WriteLine($"{first} == {new RationalNumber(1, 2)} : {first == new RationalNumber(1, 2)}");
        Console.WriteLine($"{first} != {second} : {first != second}");
        Console.WriteLine($"{first} < {second} : {first < second}");
        Console.WriteLine($"{first} <= {second} : {first <= second}");
        Console.WriteLine($"{first} > {second} : {first > second}");
        Console.WriteLine($"{first} >= {second} : {first >= second}");
        Console.WriteLine();

        Console.WriteLine("Проверка сокращения дробей:");
        Console.WriteLine($"5/10 => {new RationalNumber(5, 10)}");
        Console.WriteLine($"10/100 => {new RationalNumber(10, 100)}");
        Console.WriteLine($"12/18 => {new RationalNumber(12, 18)}");
        Console.WriteLine();

        Console.WriteLine("Проверка вывода целой дроби:");
        Console.WriteLine($"4/2 => {new RationalNumber(4, 2)}");
        Console.WriteLine($"15/5 => {new RationalNumber(15, 5)}");
        Console.WriteLine();

        Console.WriteLine("Проверка отрицательных чисел:");
        Console.WriteLine($"1/-2 => {new RationalNumber(1, -2)}");
        Console.WriteLine($"-1/2 => {new RationalNumber(-1, 2)}");
        Console.WriteLine($"-1/-2 => {new RationalNumber(-1, -2)}");
        Console.WriteLine();

        Console.WriteLine("Проверка Denominator = 0:");

        try
        {
            var wrongNumber = new RationalNumber(1, 0);
            Console.WriteLine(wrongNumber);
        }
        catch (DivideByZeroException exception)
        {
            Console.WriteLine($"Ошибка: {exception.Message}");
        }

        Console.WriteLine();

        Console.WriteLine("Проверка деления на нулевую дробь:");

        try
        {
            var result = new RationalNumber(1, 2) / new RationalNumber(0, 5);
            Console.WriteLine(result);
        }
        catch (DivideByZeroException exception)
        {
            Console.WriteLine($"Ошибка: {exception.Message}");
        }
    }

    /// <summary>
    /// Запуск задания 2
    /// </summary>
    public void RunTask2()
    {
        Console.WriteLine("Задание 2 не реализовано.");
    }

    /// <summary>
    /// Запуск задания 3
    /// </summary>
    public void RunTask3()
    {
        Console.WriteLine("Задание 3 не реализовано.");
    }
}
