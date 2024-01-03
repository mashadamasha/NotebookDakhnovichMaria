namespace NotebookDakhnovichMaria.Presenter;

public class ContactData
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set;  }


    public ContactData(string name, string surname, string phoneNumber, string email)
    {
        Name = name;
        Surname = surname;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public override string? ToString()
    {
        return $"Name: {Name}\nSurname: {Surname}\nPhone: {PhoneNumber}\nE-mail: {Email}"; 
    }
}