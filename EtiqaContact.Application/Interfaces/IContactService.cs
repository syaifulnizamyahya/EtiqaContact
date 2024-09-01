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
    Task<ContactDto> CreateAsync(CreateContactDto createContactDto);
}
