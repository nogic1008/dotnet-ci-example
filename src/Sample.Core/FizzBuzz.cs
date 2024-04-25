namespace Sample.Core;

/// <summary>
/// Extension methods for int.
/// </summary>
public static class FizzBuzz
{
    /// <summary>
    /// Convert the integer to FizzBuzz format.
    /// </summary>
    /// <param name="i">target integer</param>
    /// <returns>
    /// "Fizz Buzz" if the integer is divisible by 15,
    /// "Buzz" if the integer is divisible by 5,
    /// "Fizz" if the integer is divisible by 3,
    /// otherwise the integer itself.
    /// </returns>
    public static string ToFizzBuzzFormat(this int i)
        => i % 15 == 0 ? "Fizz Buzz"
        : i % 5 == 0 ? "Buzz"
        : i % 3 == 0 ? "Fizz"
        : i.ToString();
}
