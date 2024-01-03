using NotebookDakhnovichMaria.Presenter;

namespace TestProject;
using Xunit;

public class UnitTest1
{
    [Fact]
    public void SearchByName_ShouldReturnMatchingContacts()
    {
        MyNotebook notebook = new MyNotebook();
        notebook.AddContact("John", "Doe", "123", "john.doe@example.com");
        notebook.AddContact("Jane", "Doe", "456", "jane.doe@example.com");
        
        List<ContactData> searchResults = notebook.SearchBy(1, "John");
        
        Assert.Equal(1, searchResults.Count);
        Assert.Equal("John", searchResults[0].Name);
    }

    [Fact]
    public void AddContact_ShouldIncreaseContactCount()
    {
        MyNotebook notebook = new MyNotebook();
        int initialCount = notebook.contacts.Count;
        
        notebook.AddContact("John", "Doe", "123", "john.doe@example.com");
        
        Assert.Equal(initialCount + 1, notebook.contacts.Count);
    }

    [Fact]
    public void SearchByInvalidCriteria_ShouldReturnEmptyList()
    {
        MyNotebook notebook = new MyNotebook();
        notebook.AddContact("John", "Doe", "123", "john.doe@example.com");
        
        List<ContactData> searchResults = notebook.SearchBy(6, "John");
        
        Assert.Null(searchResults);
    }
}