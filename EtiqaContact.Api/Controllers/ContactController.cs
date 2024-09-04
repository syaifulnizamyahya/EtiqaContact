using EtiqaContact.Application.DTOs;
using EtiqaContact.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog.Context;

namespace EtiqaContact.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;
    private readonly ILogger<ContactsController> _logger;

    public ContactsController(IContactService contactService, ILogger<ContactsController> logger)
    {
        _contactService = contactService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContactDto>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        using (LogContext.PushProperty("ActionName", nameof(GetAll)))
        {
            _logger.LogInformation("Get Contacts page {PageNumber}, page size {PageSize}.", pageNumber, pageSize);
            var contacts = await _contactService.GetAllAsync(pageNumber, pageSize);
            return Ok(contacts);
        }
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<ContactDto>> GetById(Guid id)
    {
        using (LogContext.PushProperty("ActionName", nameof(GetById)))
        {
            _logger.LogInformation("Get Contact with {ContactId}.", id);
            var contact = await _contactService.GetByIdAsync(id);
            if (contact == null)
            {
                _logger.LogInformation("Contact with {ContactId} not found.", id);
                return NotFound();
            }
            return Ok(contact);
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ContactDto>> Create(CreateContactDto createContactDto)
    {
        if(!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid model state.");
            return BadRequest(ModelState);
        }

        using (LogContext.PushProperty("ActionName", nameof(Create)))
        {
            _logger.LogInformation("Creating Contact.");
            var contact = await _contactService.CreateAsync(createContactDto);
            _logger.LogInformation("Contact with {ContactId} created.", contact.Id);
            return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
        }
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Update(Guid id, CreateContactDto createContactDto)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid model state.");
            return BadRequest(ModelState);
        }

        using (LogContext.PushProperty("ActionName", nameof(Update)))
        {
            _logger.LogInformation("Updating Contact with {ContactId}.", id);
            await _contactService.UpdateAsync(id, createContactDto);
            _logger.LogInformation("Contact with {ContactId} updated.", id);
            return NoContent();
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Delete(Guid id)
    {
        using (LogContext.PushProperty("ActionName", nameof(Delete)))
        {
            _logger.LogInformation("Deleting Contact with {ContactId}.", id);
            await _contactService.DeleteAsync(id);
            _logger.LogInformation("Contact with {ContactId} deleted.", id);
            return NoContent();
        }
    }
}
