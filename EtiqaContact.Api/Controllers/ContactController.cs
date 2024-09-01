using EtiqaContact.Application.DTOs;
using EtiqaContact.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<ActionResult<IEnumerable<ContactDto>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var contacts = await _contactService.GetAllAsync(pageNumber, pageSize);
        return Ok(contacts);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<ContactDto>> GetById(Guid id)
    {
        var contact = await _contactService.GetByIdAsync(id);
        if (contact == null)
        {
            return NotFound();
        }
        return Ok(contact);
    }

    [HttpPost]
    [Authorize(Roles ="Admin")]
    public async Task<ActionResult<ContactDto>> Create(CreateContactDto createContactDto)
    {
        var contact = await _contactService.CreateAsync(createContactDto);
        return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Update(Guid id, CreateContactDto createContactDto)
    {
        await _contactService.UpdateAsync(id, createContactDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _contactService.DeleteAsync(id);
        return NoContent();
    }
}
