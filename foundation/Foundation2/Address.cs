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
