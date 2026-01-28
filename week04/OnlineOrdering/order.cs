using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0;
        
        foreach (Product product in _products)
        {
            totalCost += product.CalculateTotalCost();
        }
        
        // Add shipping cost
        double shippingCost = _customer.IsInUSA() ? 5 : 35;
        totalCost += shippingCost;
        
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in _products)
        {
            packingLabel += $"Product: {product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }

    // Getters
    public List<Product> GetProducts() => _products;
    public Customer GetCustomer() => _customer;

    // Setters
    public void SetProducts(List<Product> products) => _products = products;
    public void SetCustomer(Customer customer) => _customer = customer;
}