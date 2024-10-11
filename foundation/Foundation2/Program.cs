using System;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = BuildOrderList();

        /// Critera 4: Fucntionality: Behaviors
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
        /// Critera 3: Fucntionality: Object Creation
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
