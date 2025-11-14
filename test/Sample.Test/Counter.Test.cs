using Sample.Core;

namespace Sample.Test;

/// <summary>
/// Unit test for <see cref="Counter"/>.
/// </summary>
[TestClass]
public sealed class CounterTest
{
    /// <summary>
    /// Counter should initialize with default value of 0.
    /// </summary>
    [TestMethod(DisplayName = $"{nameof(Counter)} > Initializes with default value")]
    public void Counter_Initializes_With_Default_Value()
    {
        var counter = new Counter();
        counter.Count.ShouldBe(0);
    }

    /// <summary>
    /// Counter should not allow negative values.
    /// </summary>
    [TestMethod(DisplayName = $"{nameof(Counter)} > Does not allow negative values")]
    public void Counter_Does_Not_Allow_Negative_Values()
    {
        var counter = new Counter { Count = -5 };
        counter.Count.ShouldBe(0);
    }

    /// <summary>
    /// Counter should increment correctly.
    /// </summary>
    [TestMethod(DisplayName = $"{nameof(Counter)} > Increments correctly")]
    public void Counter_Increments_Correctly()
    {
        var counter = new Counter { Count = 5 };
        counter.Increment();
        counter.Count.ShouldBe(6);
        counter.Increment(4);
        counter.Count.ShouldBe(10);
    }

    /// <summary>
    /// Counter should decrement correctly but not go negative.
    /// </summary>
    [TestMethod(DisplayName = $"{nameof(Counter)} > Decrements correctly")]
    public void Counter_Decrements_Correctly()
    {
        var counter = new Counter { Count = 5 };
        counter.Decrement();
        counter.Count.ShouldBe(4);
        counter.Decrement(10);
        counter.Count.ShouldBe(0);
    }
}
