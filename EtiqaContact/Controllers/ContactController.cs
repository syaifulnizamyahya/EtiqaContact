using EtiqaContact.Models;
using EtiqaContact.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EtiqaContact.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly ContactRepository _contactRepository;

    public ContactController(ContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Contact>> GetAllContacts()
    {
        return Ok(_contactRepository.GetAllContacts());
    }

    [HttpGet("{id}")]
    public ActionResult<Contact> GetContactById(Guid id)
    {
        var contact = _contactRepository.GetContactById(id);
        if (contact == null)
        {
            return NotFound();
        }
        return Ok(contact);
    }

    [HttpPost]
    public ActionResult<Contact> CreateContact([FromBody] Contact contact)
    {
        _contactRepository.AddContact(contact);
        return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateContact(Guid id, [FromBody] Contact contact)
    {
        if(id != contact.Id)
        {
            return BadRequest();
        }

        var existingContact = _contactRepository.GetContactById(id);
        if (existingContact == null)
        {
            return NotFound();
        }

        _contactRepository.UpdateContact(contact);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteContact(Guid id)
    {
        var contact = _contactRepository.GetContactById(id);
        if (contact == null)
        {
            return NotFound();
        }

        _contactRepository.DeleteContact(id);
        return NoContent();
    }
}
