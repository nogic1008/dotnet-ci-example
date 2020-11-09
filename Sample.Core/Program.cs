using System;
using System.Linq;

namespace Sample.Core
{
    internal static class Program
    {
        private static void Main()
            => Console.WriteLine(
                string.Join(", ", Enumerable.Range(1, 20).Select(i => i.ToFizzBuzzFormat()))
            );
    }
}