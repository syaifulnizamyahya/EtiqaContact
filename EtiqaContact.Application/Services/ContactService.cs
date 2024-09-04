using AutoMapper;
using EtiqaContact.Application.DTOs;
using EtiqaContact.Application.Interfaces;
using EtiqaContact.Domain.Entities;
using EtiqaContact.Domain.Repositories;

namespace EtiqaContact.Application.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public ContactService(IContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ContactDto>> GetAllAsync(int pageNumber, int pageSize)
    {
        var contacts = await _contactRepository.GetAllAsync(pageNumber, pageSize);
        return _mapper.Map<List<ContactDto>>(contacts);
    }

    public async Task<ContactDto> GetByIdAsync(Guid id)
    {
        var contact = await _contactRepository.GetByIdAsync(id);
        return _mapper.Map<ContactDto>(contact);
    }

    public async Task<ContactDto> CreateAsync(CreateContactDto createContactDto)
    {
        var contact = _mapper.Map<Contact>(createContactDto);
        var createdContact = await _contactRepository.AddAsync(contact);
        return _mapper.Map<ContactDto>(createdContact);
    }

    public async Task UpdateAsync(Guid id, CreateContactDto createContactDto)
    {
        var contact = await _contactRepository.GetByIdAsync(id);
        if (contact == null)
        {
            throw new KeyNotFoundException("Contact not found");
        }
        _mapper.Map(createContactDto, contact);
        await _contactRepository.UpdateAsync(contact);
    }

    public async Task DeleteAsync(Guid id)
    {
        var contact = await _contactRepository.GetByIdAsync(id);
        if (contact == null)
        {
            throw new KeyNotFoundException("Contact not found");
        }
        await _contactRepository.DeleteAsync(id);
    }
}
