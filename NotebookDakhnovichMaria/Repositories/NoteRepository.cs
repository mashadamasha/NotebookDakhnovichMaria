using Microsoft.EntityFrameworkCore;
using NotebookDakhnovichMaria.DatabaseFramework;

namespace NotebookDakhnovichMaria.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly NoteContext _context;

    public NoteRepository(NoteContext context)
    {
        _context = context;
    }

    public async Task<List<ContactDataDto>> ShowAllContacts()
    {
        return await _context.Contacts.ToListAsync();
    }

    public async Task<List<ContactDataDto>> SearchBy(int search, string searchString)
    {
        switch (search)
        {
            case 1:
                return await SearchByName(searchString);
            case 2:
                return await SearchBySurname(searchString);
            case 3:
                return await SearchByNameAndSurname(searchString);
            case 4:
                return await SearchByPhone(searchString);
            case 5:
                return await SearchByEmail(searchString);
            default:
                throw new InvalidOperationException("Invalid search type.");
        }
    }
    
    private async Task<List<ContactDataDto>> SearchByName(string searchString)
    {
        return await _context.Contacts
            .Where(contact => contact._name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    private async Task<List<ContactDataDto>> SearchBySurname(string searchString)
    {
        return await _context.Contacts
            .Where(contact => contact._surname.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    private async Task<List<ContactDataDto>> SearchByNameAndSurname(string searchString)
    {
        string[] searchStrings = searchString.Split(' ');
        return await _context.Contacts
            .Where(contact => contact._name.Contains(searchStrings[0], StringComparison.OrdinalIgnoreCase) &&
                              contact._surname.Contains(searchStrings[1], StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    private async Task<List<ContactDataDto>> SearchByPhone(string searchString)
    {
        return await _context.Contacts
            .Where(contact => contact._phoneNumber.Contains(searchString))
            .ToListAsync();
    }

    private async Task<List<ContactDataDto>> SearchByEmail(string searchString)
    {
        return await _context.Contacts
            .Where(contact => contact._email.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    public async Task AddContact(ContactDataDto contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
    }
}