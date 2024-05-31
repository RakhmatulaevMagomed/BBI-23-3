using System;

struct Contact
{
    public int contactId;
    public string firstName;
    public string lastName;
    public string phoneNumber;
    public string email;

    public Contact(int id, string fName, string lName, string phone, string mail)
    {
        contactId = id;
        firstName = fName;
        lastName = lName;
        phoneNumber = phone;
        email = mail;
    }

    public void DisplayContactInfo()
    {
        Console.WriteLine($"ID: {contactId}");
        Console.WriteLine($"First Name: {firstName}");
        Console.WriteLine($"Last Name: {lastName}");
        Console.WriteLine($"Phone Number: {phoneNumber}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Contact[] contacts = new Contact[5];
        contacts[0] = new Contact(1, "Maga", "Rakhmatulaev", "79661824719", "magra@mail.ru");
        contacts[1] = new Contact(2, "Artur", "Guskov", "79987654321", "argus@mail.ru");
        contacts[2] = new Contact(3, "Misha", "Samaev", "99456789123", "mishsa@mail.ru");
        contacts[3] = new Contact(4, "Ksenia", "Kirchu", "78912345642", "ksuki@mail.ru");
        contacts[4] = new Contact(5, "Sofia", "Amelichkina", "99321654987", "sofaam@mail.ru");

        Array.Sort(contacts, (x, y) => x.lastName.CompareTo(y.lastName) != 0 ? x.lastName.CompareTo(y.lastName) : x.firstName.CompareTo(y.firstName));

        Console.WriteLine("Contacts table:");
        foreach (var contact in contacts)
        {
            contact.DisplayContactInfo();
        }
    }
}