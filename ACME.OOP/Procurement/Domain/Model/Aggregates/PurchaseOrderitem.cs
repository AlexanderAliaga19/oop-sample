using ACME.OOP.Procurement.Domain.Model.valueObjetcs;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.Procurement.Domain.Model.Aggregates;

/// <summary>
/// represents an item in a purchase order.
/// </summary>
/// <param name="productId">The identifier of the product being ordered.</param>
/// <param name="quantity">The quantity of the product being ordered. Must be greater than zero.</param>
/// <param name="unitPrice">The price per unit of the product. Must be a valid <see cref="Money"/> instance.</param>
///
/// <exception cref="ArgumentNullException">Thrown when any of the parameters are null.</exception>
/// <exception cref="ArgumentOutOfRangeException">Thrown when the quantity is less than or equal to zero.</exception>
public class PurchaseOrderitem(ProductId productId, int quantity, Money unitPrice)
{
    public ProductId ProductId { get; } = productId ?? throw new ArgumentNullException(nameof(productId));
    public int Quantity { get; } = quantity > 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
    public Money UnitPrice { get; } = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
    
    /// <summary>
    /// calculates the total price of the item.
    /// </summary>
    /// <returns>A new instance of <see cref="Money"/> representing the total price of the item.</returns>
    public Money CalculateItemTotal() => new Money(Quantity * UnitPrice.Amount, UnitPrice.Currency);
}