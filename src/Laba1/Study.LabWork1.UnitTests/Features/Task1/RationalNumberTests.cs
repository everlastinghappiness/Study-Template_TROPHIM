using System;
using Study.LabWork1.Features.Task1;
using Xunit;

namespace Study.LabWork1.UnitTests.Features.Task1;

public sealed class RationalNumberTests
{
    [Fact]
    public void Constructor_WhenDenominatorIsZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => new RationalNumber(1, 0));
    }

    [Fact]
    public void Constructor_ReducesFraction()
    {
        var number = new RationalNumber(5, 10);

        Assert.Equal(1, number.Numerator);
        Assert.Equal(2, number.Denominator);
        Assert.Equal("1/2", number.ToString());
    }

    [Fact]
    public void ToString_WhenFractionIsInteger_ReturnsOnlyNumerator()
    {
        var number = new RationalNumber(4, 2);

        Assert.Equal("2", number.ToString());
    }

    [Theory]
    [InlineData(1, -2, "-1/2")]
    [InlineData(-1, 2, "-1/2")]
    [InlineData(-1, -2, "1/2")]
    public void Constructor_NormalizesNegativeSign(long numerator, long denominator, string expected)
    {
        var number = new RationalNumber(numerator, denominator);

        Assert.Equal(expected, number.ToString());
    }

    [Fact]
    public void Addition_ReturnsCorrectResult()
    {
        var result = new RationalNumber(1, 2) + new RationalNumber(1, 3);

        Assert.Equal(new RationalNumber(5, 6), result);
    }

    [Fact]
    public void Subtraction_ReturnsCorrectResult()
    {
        var result = new RationalNumber(3, 4) - new RationalNumber(1, 2);

        Assert.Equal(new RationalNumber(1, 4), result);
    }

    [Fact]
    public void Multiplication_ReturnsCorrectResult()
    {
        var result = new RationalNumber(2, 3) * new RationalNumber(9, 10);

        Assert.Equal(new RationalNumber(3, 5), result);
    }

    [Fact]
    public void Division_ReturnsCorrectResult()
    {
        var result = new RationalNumber(2, 3) / new RationalNumber(4, 5);

        Assert.Equal(new RationalNumber(5, 6), result);
    }

    [Fact]
    public void Division_WhenRightNumberIsZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() =>
            new RationalNumber(1, 2) / new RationalNumber(0, 5));
    }

    [Fact]
    public void EqualityOperators_CompareByValue()
    {
        var first = new RationalNumber(2, 4);
        var second = new RationalNumber(1, 2);

        Assert.True(first == second);
        Assert.False(first != second);
    }

    [Fact]
    public void ComparisonOperators_CompareByValue()
    {
        var first = new RationalNumber(1, 2);
        var second = new RationalNumber(2, 3);
        var third = new RationalNumber(4, 6);

        Assert.True(first < second);
        Assert.True(second > first);
        Assert.True(second >= third);
        Assert.True(third <= second);
    }
}
