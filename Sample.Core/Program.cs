using System;
using System.Linq;

namespace Sample.Core
{
    internal class Program
    {
        private static void Main()
            => Console.WriteLine(
                string.Join(", ", Enumerable.Range(1, 20).Select(i => i.ToFizzBuzzFormat()))
            );
    }

    public static class FizzBuzz
    {
        public static string ToFizzBuzzFormat(this int i)
            => i % 15 == 0 ? "Fizz Buzz"
            : i % 5 == 0 ? "Buzz"
            : i % 3 == 0 ? "Fizz"
            : i.ToString();
    }
}
