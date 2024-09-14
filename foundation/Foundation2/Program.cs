using System;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = BuildOrderList();
        foreach (Order order in orders) {
            Console.WriteLine("=====================================================================================");
            Console.WriteLine();

            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.PackingLabel());

            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.ShippingLabel());

            Console.WriteLine("Total Price:");
            Console.WriteLine(order.TotalCost().ToString("C2"));

            Console.WriteLine();
        }
    }

    static List<Order> BuildOrderList() {
        return new List<Order> {
            new Order(
                new Customer(
                    "Bob Johnson",
                    new Address(
                        "123 Main St",
                        "Milwaukee",
                        "WI",
                        "USA"
                    )
                ),
                new List<Product> {
                    new Product(
                        "Thingamizer",
                        "THM0014",
                        4.95f,
                        3
                    ),
                    new Product(
                        "Doohickey",
                        "DHK0014",
                        7.45f,
                        10
                    ),
                    new Product(
                        "DealieBob",
                        "DLB0001",
                        19.6f,
                        5
                    )
                }
            ),
            new Order(
                new Customer(
                    "Maria Sanchez",
                    new Address(
                        "65 Avenida 32",
                        "Lima",
                        "Lima",
                        "Peru"
                    )
                ),
                new List<Product> {
                    new Product(
                        "Cosa",
                        "CSA0239",
                        23.5f,
                        4
                    ),
                    new Product(
                        "Surtido",
                        "STD0012",
                        9.2f,
                        7
                    )
                }
            )
        };
    }
}

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

class Customer {
    /// Critera 1: Abstraction Classes
    string _name;
    Address _address;

    public Customer(string name, Address address) {
        _name = name;
        _address = address;
    }

    public bool InUSA() {
        return _address.InUSA();
    }

    public string GetFullName() {
        return _name;
    }

    public string GetFullAddress() {
        return _address.GetFullAddress();
    }
}

class Address {
    /// Critera 1: Abstraction Classes
    string _street;
    string _city;
    string _stateProvince;
    string _country;

    public Address(string street, string city, string stateProvince, string country) {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public bool InUSA() {
        return _country == "USA";
    }

    public string GetFullAddress() {
        return $"{_street}\n{_city}, {_stateProvince}\n{_country}";
    }
}

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