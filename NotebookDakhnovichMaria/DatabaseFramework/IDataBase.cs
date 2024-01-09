using NotebookDakhnovichMaria.Presenter;

namespace NotebookDakhnovichMaria.DatabaseFramework;

public interface IDataBase
{
    List<ContactData> LoadContacts();
    void SaveContacts(MyNotebook contacts);
}