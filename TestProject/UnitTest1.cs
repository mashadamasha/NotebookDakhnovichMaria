using Moq;
using NotebookDakhnovichMaria.DatabaseFramework;
using NotebookDakhnovichMaria.Presenter;

namespace TestProject;
using Xunit;

public class UnitTest1
{
    [Fact]
    public void AddContact_ShouldAddtoList()
    {
        var moq = new Mock<IDataBase>();
        moq.Setup(r => r.LoadContacts()).Returns(new List<ContactData>());

        var contactList = new MyNotebook(moq.Object);
        
        contactList.AddContact("test", "test2", "test3", "test4");
        var contactfromlist = contactList.contacts.First();
        
        Assert.Equal("test", contactfromlist.Name);
        Assert.Equal("test2", contactfromlist.Surname);
        Assert.Equal("test3", contactfromlist.PhoneNumber);
        Assert.Equal("test4", contactfromlist.Email);
    }

    [Fact]
    public void AddContact_DbHasThis()
    {
        var moq = new Mock<IDataBase>();
        moq.Setup(r => r.LoadContacts()).Returns(new List<ContactData>());
        var contactList = new MyNotebook(moq.Object);

        Assert.Empty(moq.Object.LoadContacts());

        contactList.AddContact("test", "test2", "test3", "test4");

        Assert.NotEmpty(moq.Object.LoadContacts());

    }
}