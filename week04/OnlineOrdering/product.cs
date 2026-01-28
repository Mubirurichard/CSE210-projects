public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double CalculateTotalCost()
    {
        return _price * _quantity;
    }

    // Getters
    public string GetName() => _name;
    public string GetProductId() => _productId;
    public double GetPrice() => _price;
    public int GetQuantity() => _quantity;

    // Setters
    public void SetName(string name) => _name = name;
    public void SetProductId(string productId) => _productId = productId;
    public void SetPrice(double price) => _price = price;
    public void SetQuantity(int quantity) => _quantity = quantity;
}