using System;

namespace Study.LabWork1.Features.Task1;

public sealed class RationalNumber : IEquatable<RationalNumber>, IComparable<RationalNumber>
{
    public long Numerator { get; }

    public long Denominator { get; }

    public RationalNumber(long numerator, long denominator)
    {
        if (denominator == 0)
        {
            throw new DivideByZeroException("Знаменатель не может быть равен нулю.");
        }

        if (numerator == 0)
        {
            Numerator = 0;
            Denominator = 1;
            return;
        }

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        long gcd = GetGreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));

        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    public static RationalNumber operator +(RationalNumber left, RationalNumber right)
    {
        return new RationalNumber(
            left.Numerator * right.Denominator + right.Numerator * left.Denominator,
            left.Denominator * right.Denominator);
    }

    public static RationalNumber operator -(RationalNumber left, RationalNumber right)
    {
        return new RationalNumber(
            left.Numerator * right.Denominator - right.Numerator * left.Denominator,
            left.Denominator * right.Denominator);
    }

    public static RationalNumber operator *(RationalNumber left, RationalNumber right)
    {
        return new RationalNumber(
            left.Numerator * right.Numerator,
            left.Denominator * right.Denominator);
    }

    public static RationalNumber operator /(RationalNumber left, RationalNumber right)
    {
        if (right.Numerator == 0)
        {
            throw new DivideByZeroException("Нельзя делить на дробь, равную нулю.");
        }

        return new RationalNumber(
            left.Numerator * right.Denominator,
            left.Denominator * right.Numerator);
    }

    public static bool operator ==(RationalNumber? left, RationalNumber? right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(RationalNumber? left, RationalNumber? right)
    {
        return !(left == right);
    }

    public static bool operator <(RationalNumber left, RationalNumber right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator >(RationalNumber left, RationalNumber right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator <=(RationalNumber left, RationalNumber right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >=(RationalNumber left, RationalNumber right)
    {
        return left.CompareTo(right) >= 0;
    }

    public int CompareTo(RationalNumber? other)
    {
        if (other is null)
        {
            return 1;
        }

        long leftValue = Numerator * other.Denominator;
        long rightValue = other.Numerator * Denominator;

        return leftValue.CompareTo(rightValue);
    }

    public bool Equals(RationalNumber? other)
    {
        if (other is null)
        {
            return false;
        }

        return Numerator == other.Numerator && Denominator == other.Denominator;
    }

    public override bool Equals(object? obj)
    {
        return obj is RationalNumber number && Equals(number);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }

    public override string ToString()
    {
        if (Denominator == 1)
        {
            return Numerator.ToString();
        }

        return $"{Numerator}/{Denominator}";
    }

    private static long GetGreatestCommonDivisor(long firstNumber, long secondNumber)
    {
        while (secondNumber != 0)
        {
            long temp = secondNumber;
            secondNumber = firstNumber % secondNumber;
            firstNumber = temp;
        }

        return firstNumber;
    }
}
