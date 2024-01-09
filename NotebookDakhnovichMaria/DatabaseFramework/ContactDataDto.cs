using NotebookDakhnovichMaria.Presenter;

namespace NotebookDakhnovichMaria.DatabaseFramework;

public class ContactDataDto
{
    public ulong id { get; set; }
    public string _name;
    public string _surname;
    public string _phoneNumber;
    public string _email;
    
    public ContactDataDto(){}

    public ContactDataDto(ContactData c)
    {
        _name = c.Name;
        _surname = c.Surname;
        _phoneNumber = c.PhoneNumber;
        _email = c.Email;
    }
}