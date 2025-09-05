using ACME.OOP.SCM.Domain.model.ValueObjetcts;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.Procurement.Domain.Model.Aggregates;
using ACME.OOP.Procurement.Domain.Model.valueObjetcs;

/// <summary>
/// Represents a purchase order in the procurement system.
/// </summary>
/// <param name="orderNumber">The unique identifier for the purchase order.</param>`
/// <param name="supplierId">The identifier of the supplier associated with the purchase order.</param>
/// <param name="orderDate">The date the purchase order was created.</param>
/// <param name="currency">The currency code for the purchase order (3-letter ISO code).</param>
///
/// <exception cref="ArgumentNullException">Thrown when orderNumber or supplierId is null.</exception>
/// <exception cref="ArgumentException">Thrown when currency is not a valid 3-letter ISO code.</exception>
public class PurchaseOrder(string orderNumber, SupplierId supplierId, DateTime orderDate, string currency)
{
    private readonly List<PurchaseOrderitem> _items = new();

    public string OrderNumber { get; } = orderNumber ?? throw new ArgumentNullException(nameof(orderNumber));
    public SupplierId SupplierId { get; } = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
    public DateTime OrderDate { get; } = orderDate;
    

    public string Currency { get; } =
        string.IsNullOrWhiteSpace(currency) || currency.Length != 3
            ? throw new ArgumentException("Currency must be a 3-letter ISO code.", nameof(currency))
            : currency;
    
    
    public IReadOnlyList<PurchaseOrderitem> Items => _items.AsReadOnly();
    
    /// <summary>
    /// Adds an item to the purchase order.
    /// </summary>
    /// <param name="productId">The identifier of the product being ordered.</param>
    /// <param name="quantity">The quantity of the product being ordered. Must be greater than zero.</param>
    /// <param name="unitPriceAmount">The price per unit of the product. Must be greater than zero.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when quantity or unitPriceAmount is less than or equal to zero.</exception>
    /// <exception cref="ArgumentNullException">Thrown when productId is null.</exception>
    public void AddItem(ProductId productId, int quantity, decimal unitPriceAmount)
    {
        ArgumentNullException.ThrowIfNull(productId);
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        if (unitPriceAmount <= 0)
            throw new ArgumentOutOfRangeException(nameof(unitPriceAmount), "Unit price must be greater than zero.");
        
        var unitPrice = new Money(unitPriceAmount, Currency);
        var item = new PurchaseOrderitem(productId, quantity, unitPrice);
        _items.Add(item);
    }
    
    /// <summary>
    /// Calculates the total amount of the purchase order by summing up the total of each item.
    /// </summary>
    /// <returns></returns>
    public Money  CalculateOrderTotal()
    {
        var totalamount = _items.Sum(item => item.CalculateItemTotal().Amount);
        return new Money(totalamount, Currency);
    }
}