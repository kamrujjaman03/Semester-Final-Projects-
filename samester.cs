using System;

// -------- Interface --------
interface IPrintable
{
    void Print();
}

// -------- Base Class --------
class Person
{
    public string Name, Phone;
    public Person(string n, string p)
    {
        Name = n; Phone = p;
    }
}

// -------- Menu Item --------
class MenuItem
{
    public double Price;
    public MenuItem(double p)
    {
        Price = p;
    }
    public static MenuItem operator +(MenuItem a, MenuItem b)
    {
        return new MenuItem(a.Price + b.Price);
    }
}

// -------- Customer --------
class Customer : Person
{
    public int Qty;
    public Customer(string n, string p, int q) : base(n, p)
    {
        Qty = q;
    }
}

// -------- Employee --------
class Employee : Person
{
    public string Designation;
    public long ID;

    public Employee(string n, string p, string d, long id)
        : base(n, p)
    {
        Designation = d;
        ID = id;
    }
}

// -------- Order --------
class Order : IPrintable
{
    Customer c;
    MenuItem m;
    double discount;

    public Order(Customer c, MenuItem m, double d)
    {
        this.c = c; this.m = m; discount = d;
    }

    double Total() => m.Price * c.Qty;

    public void Print()
    {
        Console.WriteLine("\n--- Order Details ---");
        Console.WriteLine("Customer Name: " + c.Name);
        Console.WriteLine("Customer Phone: " + c.Phone);
        Console.WriteLine("Quantity: " + c.Qty);
        Console.WriteLine("Total Amount: " + Total());
        Console.WriteLine("Discount: " + discount);
        Console.WriteLine("Payable Amount: " + (Total() - discount));
    }
}

// -------- Main --------
class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to BANGLAMALLS");

        MenuItem combo = new MenuItem(60) + new MenuItem(180);
        Console.WriteLine("Combo Item Price: " + combo.Price);

        Employee emp = new Employee("Karim", "01819-987654", "Salesman", 2243000000);

        Console.WriteLine("\n--- Sales Information ---");
        Console.WriteLine("Employee Name: " + emp.Name);
        Console.WriteLine("Designation: " + emp.Designation);
        Console.WriteLine("ID: " + emp.ID);

        // -------- Customer Input --------
        Console.Write("\nEnter Customer Name: ");
        string cname = Console.ReadLine();

        Console.Write("Enter Customer Phone: ");
        string cphone = Console.ReadLine();

        Console.Write("Enter combo package quantity (Max 3): ");
        int qty = int.Parse(Console.ReadLine());

        if (qty > 3)
        {
            Console.WriteLine("Apni 3 ta combo package er besi nite parben na");
            return;
        }

        double discount = (qty == 2) ? 50 : (qty == 3) ? 70 : 0;

        Customer cust = new Customer(cname, cphone, qty);
        Order order = new Order(cust, combo, discount);
        order.Print();

        // -------- Payment --------
        Console.WriteLine("\nPlease type your payment method:");
        string method = Console.ReadLine().ToLower();

        if (method == "bkash" || method == "nagod" ||
            method == "rocket" || method == "bank")
            Console.WriteLine("Your payment is successful");
        else
            Console.WriteLine("Invalid payment method");

        Console.WriteLine("\n=== Code Execution Successful ===");
    }
}