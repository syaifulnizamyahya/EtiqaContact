using EtiqaContact.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtiqaContact.Application.Interfaces;

public interface IContactService
{
    Task<IEnumerable<ContactDto>> GetAllAsync();
    Task<ContactDto> GetByIdAsync(Guid id);
    Task<ContactDto> CreateAsync(CreateContactDto createContactDto);
    Task UpdateAsync(Guid id, CreateContactDto createContactDto);
    Task DeleteAsync(Guid id);
}
