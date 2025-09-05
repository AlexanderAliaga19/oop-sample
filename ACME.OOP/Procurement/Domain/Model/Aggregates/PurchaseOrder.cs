using ACME.OOP.SCM.Domain.model.ValueObjetcts;

namespace ACME.OOP.Procurement.Domain.Model.Aggregates;
using ACME.OOP.Procurement.Domain.Model.valueObjetcs;

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
    
}