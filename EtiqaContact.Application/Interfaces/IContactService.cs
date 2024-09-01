using EtiqaContact.Application.DTOs;

namespace EtiqaContact.Application.Interfaces;

public interface IContactService
{
    Task<IEnumerable<ContactDto>> GetAllAsync();
    Task<ContactDto> GetByIdAsync(Guid id);
    Task<ContactDto> CreateAsync(CreateContactDto createContactDto);
    Task UpdateAsync(Guid id, CreateContactDto createContactDto);
    Task DeleteAsync(Guid id);
}
