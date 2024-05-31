using System;

abstract class Contact
{
    public int contactId;
    public string firstName;
    public string lastName;

    public Contact(int id, string fName, string lName)
    {
        contactId = id;
        firstName = fName;
        lastName = lName;
    }

    public abstract void DisplayContactInfo();
}

class Employee : Contact
{
    public double salary;
    public DateTime hireDate;

    public Employee(int id, string fName, string lName, double sal, DateTime date) : base(id, fName, lName)
    {
        salary = sal;
        hireDate = date;
    }

    public override void DisplayContactInfo()
    {
        Console.WriteLine($"ID: {contactId}");
        Console.WriteLine($"First Name: {firstName}");
        Console.WriteLine($"Last Name: {lastName}");
        Console.WriteLine($"Salary: {salary}");
        Console.WriteLine($"Hire Date: {hireDate}");
        Console.WriteLine();
    }
}

class Counteragent : Contact
{
    public double contractCost;
    public int contractDuration;

    public Counteragent(int id, string fName, string lName, double cost, int duration) : base(id, fName, lName)
    {
        contractCost = cost;
        contractDuration = duration;
    }

    public override void DisplayContactInfo()
    {
        Console.WriteLine($"ID: {contactId}");
        Console.WriteLine($"First Name: {firstName}");
        Console.WriteLine($"Last Name: {lastName}");
        Console.WriteLine($"Contract Cost: {contractCost}");
        Console.WriteLine($"Contract Duration: {contractDuration} days");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Contact[] contacts = new Contact[10];

        contacts[0] = new Employee(1, "Maga", "Rakhmatulaev", 50000, new DateTime(2022, 5, 10));
        contacts[1] = new Employee(2, "Artur", "Guskov", 60000, new DateTime(2021, 8, 15));
        contacts[2] = new Employee(3, "Misha", "Samaev", 55000, new DateTime(2023, 2, 20));
        contacts[3] = new Employee(4, "Ksenia", "Kirchu", 52000, new DateTime(2020, 12, 5));
        contacts[4] = new Employee(5, "Sofia", "Amelichkina", 53000, new DateTime(2024, 6, 30));
        contacts[5] = new Counteragent(6, "Maga", "Rakhmatulaev", 10000, 90);
        contacts[6] = new Counteragent(7, "Artur", "Guskov", 12000, 120);
        contacts[7] = new Counteragent(8, "Misha", "Samaev", 15000, 180);
        contacts[8] = new Counteragent(9, "Ksenia", "Kirchu", 13000, 150);
        contacts[9] = new Counteragent(10, "Sofia", "Amelichkina", 11000, 100);

        Array.Sort(contacts, (x, y) => x.lastName.CompareTo(y.lastName) != 0 ? x.lastName.CompareTo(y.lastName) : x.firstName.CompareTo(y.firstName));

        Console.WriteLine("Employees table:");
        foreach (var contact in contacts)
        {
            if (contact is Employee)
                contact.DisplayContactInfo();
        }

        Console.WriteLine("\nCounteragents table:");
        foreach (var contact in contacts)
        {
            if (contact is Counteragent)
                contact.DisplayContactInfo();
        }

        Console.WriteLine("\nAll contacts table:");
        foreach (var contact in contacts)
        {
            contact.DisplayContactInfo();
        }
    }
}