class Customer {
    /// Critera 1: Abstraction Classes
    private string _name;
    private Address _address;

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
