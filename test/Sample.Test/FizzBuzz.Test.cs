using Xunit;
using static Sample.Core.FizzBuzz;

namespace Sample.Test;

/// <summary>
/// Unit test for <see cref="Core.FizzBuzz"/>.
/// </summary>
public sealed class FizzBuzzTest
{
    /// <summary>
    /// When <paramref name="i"/> is not devided by 3 and 5, <see cref="Core.FizzBuzz.ToFizzBuzzFormat"/> should return the number as string.
    /// </summary>
    /// <param name="i">input</param>
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(-1)]
    public void When_No_Devided_3or5_ToFizzBuzzFormat_Returns_NumberString(int i)
        => Assert.Equal(i.ToString(), i.ToFizzBuzzFormat());

    /// <summary>
    /// When <paramref name="i"/> is devided by 3, <see cref="Core.FizzBuzz.ToFizzBuzzFormat"/> should return "Fizz".
    /// </summary>
    /// <param name="i">input</param>
    [Theory]
    [InlineData(3)]
    [InlineData(-3)]
    [InlineData(123456789)]
    public void When_Devided_3_ToFizzBuzzFormat_Returns_Fizz(int i)
        => Assert.Equal("Fizz", i.ToFizzBuzzFormat());

    /// <summary>
    /// When <paramref name="i"/> is devided by 5, <see cref="Core.FizzBuzz.ToFizzBuzzFormat"/> should return "Buzz".
    /// </summary>
    /// <param name="i">input</param>
    [Theory]
    [InlineData(5)]
    [InlineData(-10)]
    [InlineData(2000)]
    public void When_Devided_5_ToFizzBuzzFormat_Returns_Buzz(int i)
        => Assert.Equal("Buzz", i.ToFizzBuzzFormat());

    /// <summary>
    /// When <paramref name="i"/> is devided by 15, <see cref="Core.FizzBuzz.ToFizzBuzzFormat"/> should return "Fizz Buzz".
    /// </summary>
    /// <param name="i">input</param>
    [Theory]
    [InlineData(0)]
    [InlineData(15)]
    [InlineData(-30)]
    public void When_Devided_15_ToFizzBuzzFormat_Returns_FizzBuzz(int i)
        => Assert.Equal("Fizz Buzz", i.ToFizzBuzzFormat());
}
