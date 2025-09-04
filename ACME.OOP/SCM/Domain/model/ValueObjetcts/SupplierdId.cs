namespace ACME.OOP.SCM.Domain.model.ValueObjetcts;
/// <summary>
/// Value object representing a supplier identifier in thr Supply Management bounded.
/// </summary>

public record SupplierId()
{
    public string Identifier { get; init; }
/// <summary>
/// Creates a new instance of <see cref="SupplierId"/>
/// </summary>
/// <param name="identifier">The unique identifier for the supplier. </param>
/// <exception cref="ArgumentException">Thrown when the identifier is null or empty</exception>
    public SupplierId (string identifier) : this()
    {
        if (string.IsNullOrEmpty(identifier))
            throw new ArgumentException("Supplier identifier cannot be null or empty", nameof(identifier));
        Identifier = identifier;
    }
}