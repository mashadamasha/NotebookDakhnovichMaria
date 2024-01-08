using Microsoft.AspNetCore.Mvc;
using NotebookDakhnovichMaria.DatabaseFramework;
using NotebookDakhnovichMaria.Repositories;

namespace WebREalization.Controllers;

[ApiController]
[Route("[controller]")]
public class WebController
{
    private readonly INoteRepository _contactRepository;

    public WebController(INoteRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    
    [HttpGet] [Route("/search-contacts")]
    public async Task<List<ContactDataDto>> Search([FromQuery] int search, string searchString)
    {
        return await _contactRepository.SearchBy(search, searchString);

    }

    [HttpPost]
    [Route("/add-new-contact")]
    public Task AddContact([FromBody] ContactDataDto contact)
    {
        return _contactRepository.AddContact(contact);
    }

    [HttpGet]
    [Route("/show-all-contacts")]
    public async Task<List<ContactDataDto>> LastTasks()
    {
        return await _contactRepository.ShowAllContacts();
    }
}