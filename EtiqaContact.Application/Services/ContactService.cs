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

    public async Task<IEnumerable<ContactDto>> GetAllAsync(int pageNumber, int pageSize)
    {
        var contacts = await _context.Contacts
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<List<ContactDto>>(contacts);
    }

    public async Task<ContactDto> GetByIdAsync(Guid id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        return _mapper.Map<ContactDto>(contact);
    }

    public async Task<ContactDto> CreateAsync(CreateContactDto createContactDto)
    {
        var contact = _mapper.Map<Contact>(createContactDto);
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return _mapper.Map<ContactDto>(contact);
    }

    public async Task UpdateAsync(Guid id, CreateContactDto createContactDto)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact != null)
        {
            _mapper.Map(createContactDto, contact);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact != null)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}
