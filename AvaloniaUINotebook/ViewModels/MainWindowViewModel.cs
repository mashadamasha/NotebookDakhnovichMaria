using System.Collections.ObjectModel;
using System.Linq;
using DynamicData;
using NotebookDakhnovichMaria.DatabaseFramework;
using ReactiveUI;

namespace AvaloniaUINotebook.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _name = "name";
    private string _surname = "surname";
    private string _phone = "9999999999";
    private string _email = "@email.com";
    
    private NoteContext _context;
    private DataBase _database;

    public ObservableCollection<ContactDataDto> ContactList { get; set; } = new ObservableCollection<ContactDataDto>();
    
    public bool _IsEditMode;
    public bool IsEditMode
    {
        get { return _IsEditMode; }
        set
        {
            this.RaiseAndSetIfChanged(ref _IsEditMode, value);
        }
    }
    
    private ContactDataDto _selectedContact;
    public ContactDataDto SelectedContact
    {
        get => _selectedContact;
        set
        { 
            this.RaiseAndSetIfChanged(ref _selectedContact, value);
            
            if (_selectedContact != null)
            {
                Name = _selectedContact._name;
                Surname = _selectedContact._surname;
                PhoneNumber = _selectedContact._phoneNumber;
                Email = _selectedContact._email;
            }
        } 
    }
    
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string Surname
    {
        get => _surname;
        set => this.RaiseAndSetIfChanged(ref _surname, value);
    }
    
    public string PhoneNumber
    {
        get => _phone;
        set => this.RaiseAndSetIfChanged(ref _phone, value);
    }
    
    public string Email
    {
        get => _email;
        set => this.RaiseAndSetIfChanged(ref _email, value);
    }

    public MainWindowViewModel()
    {
        _context = new NoteContext();
        _database = new DataBase(_context);
        var contacts = _context.Contacts.ToList();
        ContactList.AddRange(contacts);
    }

    public void EnableEditing()
    {
        IsEditMode = true;
        SelectedContact = null;
        Name = "";
        Surname = "";
        PhoneNumber = "";
        Email = "";
    }

    public void SaveNewContact()
    {
        var contact = new ContactDataDto
        {
            _name = Name,
            _surname = Surname,
            _phoneNumber = PhoneNumber,
            _email = Email,
            id = (ulong) (ContactList.Count() + 1)
        };
        
        ContactList.Add(contact);
        
        IsEditMode = false;
        _database.SaveContacts(ContactList);
    }
}