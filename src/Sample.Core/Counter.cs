namespace Sample.Core;

/// <summary>
/// Example class demonstrating C# 14 features.
/// </summary>
public class Counter
{
    /// <summary>
    /// Gets or sets the count value with automatic validation using the field keyword.
    /// </summary>
    public int Count
    {
        get => field;
        set => field = value < 0 ? 0 : value;
    }

    /// <summary>
    /// Increments the counter by the specified amount.
    /// </summary>
    /// <param name="amount">Amount to increment.</param>
    public void Increment(int amount = 1) => this.Count += amount;

    /// <summary>
    /// Decrements the counter by the specified amount.
    /// </summary>
    /// <param name="amount">Amount to decrement.</param>
    public void Decrement(int amount = 1) => this.Count -= amount;
}
