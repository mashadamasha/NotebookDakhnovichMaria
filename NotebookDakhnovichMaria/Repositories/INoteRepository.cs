using NotebookDakhnovichMaria.DatabaseFramework;

namespace NotebookDakhnovichMaria.Repositories;

public interface INoteRepository
{
    Task<List<ContactDataDto>> ShowAllContacts();
    Task<List<ContactDataDto>> SearchBy(int search, string searchString);
    Task AddContact(ContactDataDto contact);
}