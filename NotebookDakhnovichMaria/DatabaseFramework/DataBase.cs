using System.Collections.ObjectModel;
using NotebookDakhnovichMaria.Presenter;

namespace NotebookDakhnovichMaria.DatabaseFramework;

public class DataBase : IDataBase
{
    private readonly NoteContext _context;

    public DataBase(NoteContext context)
    {
        _context = context;
    }

    public List<ContactData> LoadContacts()
    {
        var contacts = _context.Contacts.ToList();

        return contacts
            .Select(contactDto => new ContactData(contactDto._name, contactDto._surname, contactDto._phoneNumber, contactDto._email))
            .GroupBy(c => c.Name)
            .Select(group => group.First()) 
            .ToList();

        
    }

    public void SaveContacts(MyNotebook contacts)
    {
        _context.Contacts.RemoveRange(_context.Contacts);
        _context.SaveChanges();

        var _contacts = contacts.contacts;
        
        _context.Contacts.AddRangeAsync(_contacts.Select(x => ConvertToDTO(x)).ToList());
        _context.SaveChanges();
    }
    
    public async void SaveContacts(ObservableCollection<ContactDataDto> contacts)
    {
        _context.Contacts.RemoveRange(_context.Contacts);
        await _context.SaveChangesAsync();

        _context.Contacts.AddRangeAsync(contacts);
        await _context.SaveChangesAsync();
    }
    
    private ContactDataDto ConvertToDTO(ContactData t)
    {
        var res = new ContactDataDto(t);
        return res;
    }
}