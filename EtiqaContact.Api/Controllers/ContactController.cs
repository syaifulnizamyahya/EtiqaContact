using EtiqaContact.Application.DTOs;
using EtiqaContact.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EtiqaContact.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContactDto>>> GetAll()
    {
        var contacts = await _contactService.GetAllAsync();
        return Ok(contacts);
    }

    [HttpPost]
    public async Task<ActionResult<ContactDto>> Create(CreateContactDto createContactDto)
    {
        var contact = await _contactService.CreateAsync(createContactDto);
        return Ok(contact);
    }
}
