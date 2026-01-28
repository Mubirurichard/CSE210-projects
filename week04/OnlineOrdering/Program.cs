using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering Program");
        Console.WriteLine("=======================\n");

        // Create addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "Ontario", "Canada");
        Address address3 = new Address("789 Pine Rd", "Los Angeles", "CA", "USA");

        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Emma Johnson", address2);
        Customer customer3 = new Customer("Robert Davis", address3);

        // Create products
        Product product1 = new Product("Laptop", "P001", 899.99, 1);
        Product product2 = new Product("Mouse", "P002", 25.50, 2);
        Product product3 = new Product("Keyboard", "P003", 45.99, 1);
        Product product4 = new Product("Monitor", "P004", 299.99, 1);
        Product product5 = new Product("Webcam", "P005", 59.99, 1);
        Product product6 = new Product("Headphones", "P006", 79.99, 2);

        // Create first order
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Create second order
        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product2);
        order2.AddProduct(product6);

        // Create third order
        Order order3 = new Order(customer3);
        order3.AddProduct(product6);
        order3.AddProduct(product3);

        // Display order details
        DisplayOrder(order1, 1);
        DisplayOrder(order2, 2);
        DisplayOrder(order3, 3);
    }

    static void DisplayOrder(Order order, int orderNumber)
    {
        Console.WriteLine($"\n=== ORDER #{orderNumber} ===");
        Console.WriteLine("\nPACKING LABEL:");
        Console.WriteLine(order.GetPackingLabel());
        
        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(order.GetShippingLabel());
        
        Console.WriteLine($"\nTOTAL PRICE: ${order.CalculateTotalCost():F2}");
        Console.WriteLine("=".PadRight(40, '='));
    }
} 