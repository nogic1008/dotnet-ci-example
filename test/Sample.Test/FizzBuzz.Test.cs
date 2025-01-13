using Sample.Core;

namespace Sample.Test;

/// <summary>
/// Unit test for <see cref="FizzBuzz"/>.
/// </summary>
[TestClass]
public sealed class FizzBuzzTest
{
    /// <summary>
    /// Generate values that satisfy the <paramref name="predicate"/>.
    /// </summary>
    /// <param name="predicate">
    /// <inheritdoc cref="Enumerable.Where{TSource}(IEnumerable{TSource}, Func{TSource, bool})" path="/param[@name='predicate']"/>
    /// </param>
    private static int[] GenerateValues(Func<int, bool> predicate)
    {   
        const int count = 10;
        int[] values = new int[count];
        for (int i = 0; i < values.Length; i++)
        {
            int value;
            do
            {
                value = FixtureFactory.Create<int>();
            } while (!predicate(value));
            values[i] = value;
        }
        return values;
    }

    /// <summary>
    /// When number is not divisible by 3 and 5, <see cref="FizzBuzz.ToFizzBuzzFormat"/> returns same value as <see cref="int.ToString()"/>.
    /// </summary>
    [TestMethod($"{nameof(FizzBuzz)} > {nameof(FizzBuzz.ToFizzBuzzFormat)}(<not a multiple of 3 and 5>) > returns same value as int.{nameof(int.ToString)}()")]
    public void When_Not_Devisible_By_3_And_5_ToFizzBuzzFormat_Returns_ToString()
        => GenerateValues(static i => i % 3 != 0 && i % 5 != 0)
            .Should().AllSatisfy(static i => i.ToFizzBuzzFormat().Should().Be(i.ToString()));

    /// <summary>
    /// When number is divisible by 3, <see cref="FizzBuzz.ToFizzBuzzFormat"/> returns "Fizz".
    /// </summary>
    [TestMethod($"{nameof(FizzBuzz)} > {nameof(FizzBuzz.ToFizzBuzzFormat)}(<multiple of 3>) > returns \"Fizz\"")]
    public void When_Devisible_By_3_ToFizzBuzzFormat_Returns_Fizz()
        => GenerateValues(static i => i % 3 == 0 && i % 5 != 0)
            .Should().AllSatisfy(static i => i.ToFizzBuzzFormat().Should().Be("Fizz"));

    /// <summary>
    /// When number is divisible by 5, <see cref="FizzBuzz.ToFizzBuzzFormat"/> returns "Buzz".
    /// </summary>
    [TestMethod($"{nameof(FizzBuzz)} > {nameof(FizzBuzz.ToFizzBuzzFormat)}(<multiple of 5>) > returns \"Buzz\"")]
    public void When_Devisible_By_5_ToFizzBuzzFormat_Returns_Buzz()
        => GenerateValues(static i => i % 3 != 0 && i % 5 == 0)
            .Should().AllSatisfy(static i => i.ToFizzBuzzFormat().Should().Be("Buzz"));

    /// <summary>
    /// When number is divisible by 15, <see cref="FizzBuzz.ToFizzBuzzFormat"/> returns "Fizz Buzz".
    /// </summary>
    [TestMethod($"{nameof(FizzBuzz)} > {nameof(FizzBuzz.ToFizzBuzzFormat)}(<multiple of 15>) > returns \"Fizz Buzz\"")]
    public void When_Devisible_By_15_ToFizzBuzzFormat_Returns_FizzBuzz()
        => GenerateValues(static i => i % 3 == 0 && i % 5 == 0)
            .Should().AllSatisfy(static i => i.ToFizzBuzzFormat().Should().Be("Fizz Buzz"));
}
