using Sample.Core;

namespace Sample.Test;

/// <summary>
/// Unit test for <see cref="FizzBuzz"/>.
/// </summary>
[TestClass]
public sealed class FizzBuzzTest
{
    /// <summary>
    /// When number is not divisible by 3 and 5, <see cref="FizzBuzz.ToFizzBuzzFormat"/> returns same value as <see cref="int.ToString()"/>.
    /// </summary>
    [TestMethod(DisplayName = $"{nameof(FizzBuzz)} > {nameof(FizzBuzz.ToFizzBuzzFormat)}(<not a multiple of 3 and 5>) > returns same value as int.{nameof(int.ToString)}()")]
    [DataRow(1)]
    [DataRow(101)]
    [DataRow(-1)]
    public void When_Not_Devisible_By_3_And_5_ToFizzBuzzFormat_Returns_ToString(int value)
        => value.ToFizzBuzzFormat().ShouldBe(value.ToString());

    /// <summary>
    /// When number is divisible by 3, <see cref="FizzBuzz.ToFizzBuzzFormat"/> returns "Fizz".
    /// </summary>
    [TestMethod(DisplayName = $"{nameof(FizzBuzz)} > {nameof(FizzBuzz.ToFizzBuzzFormat)}(<multiple of 3>) > returns \"Fizz\"")]
    [DataRow(3)]
    [DataRow(303)]
    [DataRow(-3)]
    public void When_Devisible_By_3_ToFizzBuzzFormat_Returns_Fizz(int value)
        => value.ToFizzBuzzFormat().ShouldBe("Fizz");

    /// <summary>
    /// When number is divisible by 5, <see cref="FizzBuzz.ToFizzBuzzFormat"/> returns "Buzz".
    /// </summary>
    [TestMethod(DisplayName = $"{nameof(FizzBuzz)} > {nameof(FizzBuzz.ToFizzBuzzFormat)}(<multiple of 5>) > returns \"Buzz\"")]
    [DataRow(5)]
    [DataRow(505)]
    [DataRow(-5)]
    public void When_Devisible_By_5_ToFizzBuzzFormat_Returns_Buzz(int value)
        => value.ToFizzBuzzFormat().ShouldBe("Buzz");

    /// <summary>
    /// When number is divisible by 15, <see cref="FizzBuzz.ToFizzBuzzFormat"/> returns "Fizz Buzz".
    /// </summary>
    [TestMethod(DisplayName = $"{nameof(FizzBuzz)} > {nameof(FizzBuzz.ToFizzBuzzFormat)}(<multiple of 15>) > returns \"Fizz Buzz\"")]
    [DataRow(15)]
    [DataRow(300)]
    [DataRow(-15)]
    public void When_Devisible_By_15_ToFizzBuzzFormat_Returns_FizzBuzz(int value)
        => value.ToFizzBuzzFormat().ShouldBe("Fizz Buzz");
}
