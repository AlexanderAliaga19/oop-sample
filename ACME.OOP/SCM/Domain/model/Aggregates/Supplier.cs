namespace ACME.OOP.SCM.Domain.model.Aggregates;
/// <summary>
/// Represents a supplier in the Supply Chain Management bounded context.
/// </summary>
/// <param name="identifier">The unique identifier for the supplier</param>
/// <param name="name">The  </param>
/// <param name="address"></param>
public class Supplier(string identifier, string name, string address)
{
    public string Identifier { get; } = identifier ?? throw new ArgumentNullException(nameof(identifier));
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
    public string Address { get; } = address ?? throw new ArgumentNullException(nameof(address));
}