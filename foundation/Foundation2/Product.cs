class Product {
    /// Critera 1: Abstraction Classes
    string _name;
    string _productId;
    float _price;
    int _quantity;

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
