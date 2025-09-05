namespace ACME.OOP.Procurement.Domain.Model.valueObjetcs;

/// <summary>
/// value object representing a product identifier in the Procurement bounded context.
/// </summary>

public record ProductId
{
    public Guid Id { get; init; }
    
    /// <summary>
    /// creates a new instance of <see cref="ProductId"/>
    /// </summary>
    /// <param name="id">The unique identifier for the product.</param>
    /// <exception cref="ArgumentException">Thrown when the identifier is empty</exception>
    public ProductId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Product identifier cannot be empty", nameof(id));
        Id = id;
    }
    
    /// <summary>
    /// generates a new <see cref="ProductId"/>
    /// </summary>
    /// <returns>A new instance of <see cref="ProductId"/></returns>
    
    public static ProductId New() => new (Guid.NewGuid());
    
    /// <summary>
    /// Returns a string representation of the product identifier.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => Id.ToString();
}