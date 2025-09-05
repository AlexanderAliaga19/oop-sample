namespace ACME.OOP.SCM.Domain.Model.ValueObjects;

/// <summary>
/// Value object representing a supplier identifier in the supply chain management bounded context.
/// </summary>
public record SuppilerId
{
    public string Identifier { get; init; }
    
    /// <summary>
    /// Creates a new instance of <see cref="SuppilerId"/>
    /// </summary>
    /// <param name="identifier">The unique identifier for the supplier.</param>
    /// <exception cref="ArgumentException">Thrown when the identifier is null or empty.</exception>
    public SuppilerId(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier))
            throw new ArgumentException("Identifier cannot be null or empty.", nameof(identifier));
        Identifier = identifier;
    }
}