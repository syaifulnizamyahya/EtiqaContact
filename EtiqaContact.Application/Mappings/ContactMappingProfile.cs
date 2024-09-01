using AutoMapper;
using EtiqaContact.Application.DTOs;
using EtiqaContact.Domain.Entities;

namespace EtiqaContact.Application.Mappings;

public class ContactMappingProfile : Profile
{
    public ContactMappingProfile()
    {
        CreateMap<Contact, ContactDto>();
        CreateMap<CreateContactDto, Contact>();
    }
}