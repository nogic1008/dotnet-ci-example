# Sample.Core

A sample .NET library demonstrating best practices for library development with FizzBuzz and Counter implementations.

## Features

- **FizzBuzz**: Extension method for converting integers to FizzBuzz format
- **Counter**: Thread-safe counter implementation with lock-free operations

## Installation

Install via NuGet Package Manager:

```console
dotnet add package Sample.Core
```

Or via Package Manager Console:

```powershell
Install-Package Sample.Core
```

## Usage

### FizzBuzz

```csharp
using Sample.Core;

// Convert integers to FizzBuzz format
var result1 = 15.ToFizzBuzzFormat(); // "Fizz Buzz"
var result2 = 5.ToFizzBuzzFormat();  // "Buzz"
var result3 = 3.ToFizzBuzzFormat();  // "Fizz"
var result4 = 7.ToFizzBuzzFormat();  // "7"
```

### Counter

```csharp
using Sample.Core;

// Create a new counter
var counter = new Counter();

// Increment the counter
counter.Increment();
counter.Increment();

// Get the current count
int count = counter.Count; // 2

// Decrement the counter
counter.Decrement();
int newCount = counter.Count; // 1
```

## Target Frameworks

- .NET Standard 2.0

Compatible with:
- .NET 5.0+
- .NET Core 2.0+
- .NET Framework 4.6.1+
- Mono
- Xamarin
- Unity

## License

This project is licensed under the MIT License - see the [LICENSE](../../LICENSE) file for details.

## Repository

Source code and issues: [https://github.com/nogic1008/dotnet-ci-example](https://github.com/nogic1008/dotnet-ci-example)
