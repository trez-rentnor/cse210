class Order {
    /// Critera 1: Abstraction Classes
    List<Product> _products;
    Customer _customer;

    public Order(Customer customer, List<Product> products) {
        _customer = customer;
        _products = products;
    }

    public float ShippingCost() {
        if (_customer.InUSA()) {
            return 5.0f;
        } else {
            return 35.0f;
        }
    }

    public float TotalCost() {
        float subtotal = _products.Aggregate(0.0f, (sum, product) => sum + product.TotalCost());
        float total = subtotal + ShippingCost();
        return total;
    }

    public string PackingLabel() {
        return _products.Aggregate("", (acc, product) => acc + product.PackingSummary() + "\n");
    }

    public string ShippingLabel() {
        return $"{_customer.GetFullName()}\n{_customer.GetFullAddress()}\n";
    }
}