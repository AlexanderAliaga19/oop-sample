namespace ACME.OOP.Procurement.Domain.Model.valueObjetcs;

public record ProductId
{
    public Guid Id { get; init; }
    
    public ProductId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Product identifier cannot be empty", nameof(id));
        Id = id;
    }
    
    public static ProductId New() => new (Guid.NewGuid());
}