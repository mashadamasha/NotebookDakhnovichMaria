namespace NotebookDakhnovichMaria.Presenter;

public interface IMyNotebook
{
    void ShowAllContacts();
    List<ContactData> SearchBy(int type, string value);
    void AddContact(string name, string surname, string phoneNumber, string email);
}