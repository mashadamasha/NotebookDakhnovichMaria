using NotebookDakhnovichMaria.DatabaseFramework;
using NotebookDakhnovichMaria.Presenter;

class Program
{
    static void Main()
    {
        IDataBase db = new DataBase(new NoteContext());
        MyNotebook contactList = new MyNotebook(db);

        while (true)
        {
            PrintMainMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    contactList.ShowAllContacts();
                    break;
                case "2":
                    SearchMenu(contactList);
                    break;
                case "3":
                    AddContactMenu(contactList);
                    break;
                case "4":
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void PrintMainMenu()
    {
        Console.WriteLine("\nMenu:");
        Console.WriteLine("1. View all contacts");
        Console.WriteLine("2. Search");
        Console.WriteLine("3. New contact");
        Console.WriteLine("4. Exit");
        Console.Write("> ");
    }

    static void SearchMenu(MyNotebook contactList)
    {
        PrintSearchMenu();

        if (int.TryParse(Console.ReadLine(), out int searchNumber) && searchNumber >= 1 && searchNumber <= 5)
        {
            Console.WriteLine("Enter the search string:");
            Console.Write("> ");
            string searchString = Console.ReadLine();

            List<ContactData> searchResults = contactList.SearchBy(searchNumber, searchString);

            if (searchResults != null && searchResults.Count > 0)
            {
                Console.WriteLine("Results ({0}):", searchResults.Count);
                foreach (var contact in searchResults)
                {
                    Console.WriteLine(contact);
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Try again.");
        }
    }

    static void PrintSearchMenu()
    {
        Console.WriteLine("\nSearch by");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Surname");
        Console.WriteLine("3. Name and Surname");
        Console.WriteLine("4. Phone");
        Console.WriteLine("5. E-mail");
        Console.Write("> ");
    }

    static void AddContactMenu(MyNotebook contactList)
    {
        Console.WriteLine("\nNew contact");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Surname: ");
        string surname = Console.ReadLine();
        Console.Write("Phone: ");
        string phone = Console.ReadLine();
        Console.Write("E-mail: ");
        string email = Console.ReadLine();

        contactList.AddContact(name, surname, phone, email);
    }
}
