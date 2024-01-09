using NotebookDakhnovichMaria.DatabaseFramework;

namespace NotebookDakhnovichMaria.Presenter;

public class MyNotebook : IMyNotebook
{
    public List<ContactData> contacts;

    public MyNotebook(IDataBase db)
    {
        contacts = db.LoadContacts();
    }

    public void ShowAllContacts()
    {
        if (!contacts.Any())
        {
            Console.WriteLine("Нет записанных контактов.");
            return;
        }
        Console.WriteLine("Список контактов:");
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }

    public List<ContactData> SearchBy(int type, string value)
    {
        switch (type)
        {
            case 1:
                return SearchByName(value);
            case 2:
                return SearchBySurname(value);
            case 3:
                return SearchByNameAndSurname(value);
            case 4:
                return SearchByPhone(value);
            case 5:
                return SearchByEmail(value);
            default:
                Console.WriteLine("Неверный ввод.");
                return null;
        }
    }

        private List<ContactData> SearchByName(string searchString)
    {
        List<ContactData> fcontacts = new List<ContactData>();
        Console.WriteLine("Enter the name to search for:");

        foreach (var contact in contacts)
        {
            if (contact.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(contact);
                fcontacts.Add(contact);
            }
        }
        return fcontacts;
    }

    private List<ContactData> SearchBySurname(string searchString)
    {
        List<ContactData> fcontacts = new List<ContactData>();
        Console.WriteLine("Enter the surname to search for:");


        foreach (var contact in contacts)
        {
            if (contact.Surname.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(contact);
                fcontacts.Add(contact);
            }
        }
        return fcontacts;
    }

    private List<ContactData> SearchByNameAndSurname(string searchString)
    {
        List<ContactData> fcontacts = new List<ContactData>();
        Console.WriteLine("Enter the name and surname to search for (separated by a space):");
        string[] searchStrings = searchString.Split(' ');
        foreach (var contact in contacts)
        {
            if (contact.Name.Contains(searchStrings[0], StringComparison.OrdinalIgnoreCase) && contact.Surname.Contains(searchStrings[1], StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(contact);
                fcontacts.Add(contact);
            }
        }
        return fcontacts;
    }

    private List<ContactData> SearchByPhone(string searchString)
    {
        List<ContactData> fcontacts = new List<ContactData>();
        Console.WriteLine("Enter the phone number to search for:");

        foreach (var contact in contacts)
        {
            if (contact.PhoneNumber.Contains(searchString))
            {
                Console.WriteLine(contact);
                fcontacts.Add(contact);
            }
        }
        return fcontacts;
    }

    private List<ContactData> SearchByEmail(string searchString)
    {
        List<ContactData> fcontacts = new List<ContactData>();
        Console.WriteLine("Enter the e-mail to search for:");

        foreach (var contact in contacts)
        {
            if (contact.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(contact);
                fcontacts.Add(contact);
            }
        }
        return fcontacts;
    }
    
    public void AddContact(string name, string surname, string phoneNumber, string email)
    {
        if (contacts.Any(c => c.Name == name && c.Surname == surname && c.PhoneNumber == phoneNumber && c.Email == email))
        {
            Console.WriteLine("Данный контакт уже существует!");
            return;
        }
        
        ContactData newContact = new ContactData(name, surname, phoneNumber, email);
        contacts.Add(newContact);
        Console.WriteLine("Контакт создан.");
    }
}