class Product {
    /// Critera 1: Abstraction Classes
    private string _name;
    private string _productId;
    private float _price;
    private int _quantity;

    public Product(string name, string productId, float price, int quantity) {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public float TotalCost() {
        return _price * _quantity;
    }

    public string PackingSummary() {
        return $"{_productId}: {_name} - {_quantity} pcs.";
    }
}
