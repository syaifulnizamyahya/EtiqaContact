using AutoMapper;
using EtiqaContact.Application.DTOs;
using EtiqaContact.Application.Interfaces;
using EtiqaContact.Domain.Entities;
using EtiqaContact.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EtiqaContact.Application.Services;

public class ContactService : IContactService
{
    private readonly ContactDbContext _context;
    private readonly IMapper _mapper;

    public ContactService(ContactDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ContactDto>> GetAllAsync()
    {
        var contacts = await _context.Contacts.ToListAsync();
        return _mapper.Map<List<ContactDto>>(contacts);
    }

    public async Task<ContactDto> CreateAsync(CreateContactDto createContactDto)
    {
        var contact = _mapper.Map<Contact>(createContactDto);
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return _mapper.Map<ContactDto>(contact);
    }

    public async Task<ContactDto> GetByIdAsync(Guid id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        return _mapper.Map<ContactDto>(contact);
    }
}
