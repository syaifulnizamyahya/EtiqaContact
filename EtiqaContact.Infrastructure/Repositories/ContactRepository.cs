using EtiqaContact.Domain.Entities;
using EtiqaContact.Domain.Repositories;
using EtiqaContact.Infrastructure.Data;


namespace EtiqaContact.Infrastructure.Repositories;

public class ContactRepository : Repository<Contact>, IContactRepository
{
    public ContactRepository(ApplicationDbContext context) : base(context)
    {
    }
}
