using System;
using System.Linq;
using Sample.Core;

string? arg1 = (args is not null && args.Length > 0) ? args[0] : null;
if (string.IsNullOrWhiteSpace(arg1) || !int.TryParse(arg1, out int repeatCount))
    repeatCount = 30;

var fizzbuzzList = Enumerable.Range(1, repeatCount).Select(i => i.ToFizzBuzzFormat());
Console.WriteLine(string.Join(", ", fizzbuzzList));
