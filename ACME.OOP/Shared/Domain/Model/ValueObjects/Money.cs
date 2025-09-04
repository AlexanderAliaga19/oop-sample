namespace ACME.OOP.Shared.Domain.Model.ValueObjects;
/// <summary>
public record Money
{
    public decimal Amount { get; init; }
    public string Currency { get; init; }
    /// <summary>
    /// creates a new instance of <see cref="Money"/>
    /// <param name="amount"> The monetary amount. </param>
    /// <param name="currency"> The currency code (ISO 4217 format). </param>
    /// <exception cref="ArgumentException"> Throw when the currency code is valid. </exception>

    public Money(decimal amount, string currency)
    {
        if (string.IsNullOrWhiteSpace(currency) || currency.Length != 3)
            throw new ArgumentException("Currency must be a 3-letter ISO code.", nameof(currency));
        
        Amount = amount;
        Currency = currency;
    }
/// <summary>
/// Returns a string representation of the monetary value.
/// </summary>
/// <returns>A string in thr format "Amount Currency"</returns>
    public override string ToString() => $"{Amount} {Currency}";

}